using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Service;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> userManager;
        readonly SignInManager<User> signInManager;
        IHomeService homeService;

        public AccountController(IHomeService homeService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.homeService = homeService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("AdditionalInformation", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public IActionResult AdditionalInformation()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AdditionalInformation(AdditionalInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                user.profile = new Profile
                {
                    name = model.Name,
                    lastName = model.Lastname,
                    mainPhoto = await homeService.getPhotoById(2),
                    userInfo = new UserInfo
                    {
                        create = DateTime.Now,
                        hrefWebSite = model.Websity,
                        personalInformation = model.PersonalInformation,
                        placeResidence = $"{model.City}, {model.Country}"
                    }
                };
                await userManager.UpdateAsync(user);
            }
            else
            {
                ModelState.AddModelError("", "Неверные данные и/или не все обязательные данные введены!");
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<ActionResult> Index(string userId)
        {
            User user = await homeService.getUserById(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile profile = user.profile;
            List<Review> reviews = await homeService.getReviewsByUserId(user.Id);
            List<UserAccountReview> userAccountReviews = new List<UserAccountReview>();

            foreach(var review in reviews)
            {
                Hotel hotel = review.hotelId != null ? await homeService.getHotelById(review.hotelId) : null;
                Landmark landmark = review.landmarkId != null ? await homeService.getLandmarkById(review.landmarkId) : null;
                Restaurant restaurant = review.restaurantId != null ? await homeService.getRestaurantById(review.restaurantId) : null;

                if (hotel != null)
                {
                    userAccountReviews.Add(new UserAccountReview
                    {
                        reviewId = review.id,
                        photo = hotel.mainPhoto,
                        countReview = hotel.reviews.Count,
                        name = hotel.name,
                        rating = hotel.rating
                    });
                }
                else if (landmark != null)
                {
                    userAccountReviews.Add(new UserAccountReview
                    {
                        reviewId = review.id,
                        photo = landmark.mainPhoto,
                        countReview = landmark.reviews.Count,
                        name = landmark.name,
                        rating = landmark.rating
                    });
                }
                else if (restaurant != null)
                {
                    userAccountReviews.Add(new UserAccountReview
                    {
                        reviewId = review.id,
                        photo = restaurant.mainPhoto,
                        countReview = restaurant.reviews.Count,
                        name = restaurant.name,
                        rating = restaurant.rating
                    });
                }
                else
                {
                    throw new Exception("Ошибка привязки отзыва!");
                }
            }

            ViewBag.userId = userId;
            ViewBag.currentUserId = userManager.GetUserId(User);
            ViewBag.hrefUserProfile = $"/Account?userId={ViewBag.currentUserId}";

            ViewBag.reviews = reviews;
            ViewBag.belongReviews = userAccountReviews;
            ViewBag.countPublications = reviews.ToArray().Length;

            ViewBag.name = profile.name;
            ViewBag.lastName = profile.lastName;
            ViewBag.mainPhoto = profile.mainPhoto.image;
            ViewBag.backgroundPhoto = profile.backgroundPhoto != null ? profile.backgroundPhoto.image : null;

            ViewBag.placeResidence = profile.userInfo.placeResidence;
            ViewBag.personalInformation = profile.userInfo.personalInformation;
            ViewBag.hrefWebSite = profile.userInfo.hrefWebSite;
            ViewBag.create = profile.userInfo.create.ToShortDateString();

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> EditAccount(IFormFile mainPhoto, string name, string homePlace, string website, string personalInformation)
        {
            User user = await homeService.getUserById(userManager.GetUserAsync(User).Result.Id);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile profile = user.profile;
            UserInfo userInfo = profile.userInfo;

            Photo profileMainPhoto = null;
            string profileName = null;
            string profileLastName = null;

            if (mainPhoto != null)
            {
                string photoName = $"~/img/{System.IO.Path.GetFileName(mainPhoto.FileName)}";

                await homeService.savePhoto(new Photo { name = photoName, image = Util.getByteImage(mainPhoto) });
                profileMainPhoto = await homeService.getPhotoByName(photoName);
            }

            if (name != null)
            {
                string[] fullName = name.Split(" ");
                if (fullName.Length == 2 && fullName[0].Length > 2)
                {
                    profileName = fullName[0];
                    profileLastName = fullName[1];
                }
            }

            await homeService.changeProfile(profile, profileMainPhoto, profileName, profileLastName, null);
            await homeService.changeUserInfo(userInfo, homePlace, website, personalInformation);

            return LocalRedirect($"~/Account?userId={userManager.GetUserAsync(User)?.Id}");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> BackgroundPhoto(IFormFile backgroundAccauntPhoto)
        {
            if (backgroundAccauntPhoto != null)
            {
                User user = await homeService.getUserById(userManager.GetUserAsync(User).Result.Id);
                string photoName = $"~/img/{System.IO.Path.GetFileName(backgroundAccauntPhoto.FileName)}";

                await homeService.savePhoto(new Photo { name = photoName, image = Util.getByteImage(backgroundAccauntPhoto) });
                await homeService.changeProfile(user.profile, null, null, null, homeService.getPhotoByName(photoName).Result);
            }

            return LocalRedirect($"~/Account?userId={userManager.GetUserId(User)}");
        }
    }
}