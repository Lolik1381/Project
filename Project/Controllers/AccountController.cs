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
        IHomeService applicationService;

        public AccountController(IHomeService homeService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ViewBag.defaultRegisterImage = await applicationService.getPhotoByName("defaultRegisterImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewBag.defaultRegisterImage = await applicationService.getPhotoByName("defaultRegisterImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

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
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> AdditionalInformation()
        {
            ViewBag.defaultAdditionalInformationImage = await applicationService.getPhotoByName("defaultAdditionalInformationImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AdditionalInformation(AdditionalInformationViewModel model)
        {
            ViewBag.defaultAdditionalInformationImage = await applicationService.getPhotoByName("defaultAdditionalInformationImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                var photo = await applicationService.getPhotoByName("defaultUserAccountImage");

                user.profile = new Profile
                {
                    name = model.Name,
                    lastName = model.Lastname,
                    mainPhoto = photo,
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
            User user = await applicationService.getUserById(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile profile = user.profile;
            List<Review> reviews = await applicationService.getReviewsByUserId(user.Id);
            List<UserAccountReview> userAccountReviews = new List<UserAccountReview>();

            foreach(var review in reviews)
            {
                Hotel hotel = review.hotelId != null ? await applicationService.getHotelById(review.hotelId) : null;
                Landmark landmark = review.landmarkId != null ? await applicationService.getLandmarkById(review.landmarkId) : null;
                Restaurant restaurant = review.restaurantId != null ? await applicationService.getRestaurantById(review.restaurantId) : null;

                if (hotel != null)
                {
                    userAccountReviews.Add(new UserAccountReview
                    {
                        reviewId = review.id,
                        photo = hotel.mainPhoto,
                        countReview = hotel.reviews.Count,
                        name = hotel.name,
                        rating = hotel.rating,
                        type = "Hotel",
                        id = review.hotelId
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
                        rating = landmark.rating,
                        type = "Landmark",
                        id = review.landmarkId
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
                        rating = restaurant.rating,
                        type = "Restaurant",
                        id = review.restaurantId
                    });
                }
                else
                {
                    throw new Exception("Ошибка привязки отзыва!");
                }
            }

            bool isAdmin = false;
            if (user != null)
            {
                IList<string> roles = await userManager.GetRolesAsync(user);
                List<string> listRoles = new List<string>(roles);

                isAdmin = listRoles.Find(role => role.Equals("admin")) != null ? true : false;
            }
            ViewBag.isAdmin = isAdmin;

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
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");
            
            ViewBag.aboutMeIcon = await applicationService.getPhotoByName("aboutMeIcon");
            ViewBag.plusIcon = await applicationService.getPhotoByName("plusIcon");
            ViewBag.adressIcon = await applicationService.getPhotoByName("adressIcon");

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> EditAccount(IFormFile mainPhoto, string name, string homePlace, string website, string personalInformation)
        {
            User user = await applicationService.getUserById(userManager.GetUserAsync(User).Result.Id);
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

                await applicationService.savePhoto(new Photo { name = photoName, image = Util.getByteImage(mainPhoto) });
                profileMainPhoto = await applicationService.getPhotoByName(photoName);
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

            await applicationService.changeProfile(profile, profileMainPhoto, profileName, profileLastName, null);
            await applicationService.changeUserInfo(userInfo, homePlace, website, personalInformation);

            return LocalRedirect($"~/Account?userId={userManager.GetUserAsync(User)?.Id}");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> BackgroundPhoto(IFormFile backgroundAccauntPhoto)
        {
            if (backgroundAccauntPhoto != null)
            {
                User user = await applicationService.getUserById(userManager.GetUserAsync(User).Result.Id);
                string photoName = $"~/img/{System.IO.Path.GetFileName(backgroundAccauntPhoto.FileName)}";

                await applicationService.savePhoto(new Photo { name = photoName, image = Util.getByteImage(backgroundAccauntPhoto) });
                await applicationService.changeProfile(user.profile, null, null, null, applicationService.getPhotoByName(photoName).Result);
            }

            return LocalRedirect($"~/Account?userId={userManager.GetUserId(User)}");
        }
    }
}