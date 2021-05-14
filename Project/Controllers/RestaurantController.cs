using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Service;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class RestaurantController : Controller
    {
        IHomeService homeService;
        readonly UserManager<User> userManager;

        public RestaurantController(IHomeService homeService, UserManager<User> userManager)
        {
            this.homeService = homeService;
            this.userManager = userManager;
        }

        public async Task<ActionResult> Index(FindModel findModel)
        {
            if (findModel.Id == 0)
            {
                return null;
            }

            User user = await userManager.GetUserAsync(User);
            Restaurant restaurant = await homeService.getRestaurantById(findModel.Id);

            List<Photo> restaurantPhoto = new List<Photo>();
            restaurantPhoto.AddRange(restaurant.photos);
            restaurantPhoto.Add(restaurant.mainPhoto);
            restaurant.reviews.ForEach(review => restaurantPhoto.AddRange(review.photos));

            Photo scenePhoto = await homeService.getPhotoByName("white.jpg");
            Photo sliderArrowLeft = await homeService.getPhotoByName("sliderLeft.jpg");
            Photo sliderArrowRight = await homeService.getPhotoByName("sliderRight.jpg");

            ViewBag.hrefUserProfile = "/Account?userId=" + user?.Id;
            ViewBag.scenePhoto = scenePhoto;
            ViewBag.restaurant = restaurant;
            ViewBag.reviews = isFind(findModel) ? await Find(findModel) : restaurant.reviews;
            ViewBag.restaurantPhotos = restaurantPhoto;
            ViewBag.sliderArrowLeft = sliderArrowLeft;
            ViewBag.sliderArrowRight = sliderArrowRight;

            if (User.Identity.IsAuthenticated)
            {
                User userWithProfile = await homeService.getUserById(user.Id);
                ViewBag.photoProfile = userWithProfile.profile.mainPhoto;
            }

            return View();
        }

        private bool isFind(FindModel findModel)
        {
            if (findModel.CheckboxDate1) return true;
            if (findModel.CheckboxDate2) return true;
            if (findModel.CheckboxDate3) return true;
            if (findModel.CheckboxDate4) return true;

            if (findModel.CheckboxrRating1) return true;
            if (findModel.CheckboxrRating2) return true;
            if (findModel.CheckboxrRating3) return true;
            if (findModel.CheckboxrRating4) return true;
            if (findModel.CheckboxrRating5) return true;

            if (findModel.textField != null) return true;
            return false;
        }

        private async Task<List<Review>> Find(FindModel findModel)
        {
            Restaurant restaurant = await homeService.getRestaurantById(findModel.Id);
            List<Review> reviews = restaurant.reviews;

            List<Review> actualReviews = null;
            if (!findModel.CheckboxDate1 && !findModel.CheckboxDate2 && !findModel.CheckboxDate3 && !findModel.CheckboxDate4)
            {
                actualReviews = getReviewByTextSearch(reviews, findModel.textField);
            }
            else
            {
                actualReviews = getReviewByDate(reviews, findModel.CheckboxDate1, findModel.CheckboxDate2, findModel.CheckboxDate3, findModel.CheckboxDate4);
                actualReviews = getReviewByTextSearch(actualReviews, findModel.textField);
            }

            if (findModel.CheckboxrRating1 || findModel.CheckboxrRating2 || findModel.CheckboxrRating3 || findModel.CheckboxrRating4 || findModel.CheckboxrRating5)
            {
                actualReviews = getReviewByRating(actualReviews, findModel.CheckboxrRating1, findModel.CheckboxrRating2, findModel.CheckboxrRating3, findModel.CheckboxrRating4, findModel.CheckboxrRating5);
            }

            return actualReviews;
        }

        private List<Review> getReviewByRating(List<Review> reviews, bool rating1, bool rating2, bool rating3, bool rating4, bool rating5)
        {
            List<Review> actualReviews = new List<Review>();

            reviews.ForEach(review =>
            {
                int rating = (int)Math.Round(review.rating);
                if (rating1 && rating == 1)
                {
                    actualReviews.Add(review);
                }
                else if (rating2 && rating == 2)
                {
                    actualReviews.Add(review);
                }
                else if (rating3 && rating == 3)
                {
                    actualReviews.Add(review);
                }
                else if (rating4 && rating == 4)
                {
                    actualReviews.Add(review);
                }
                else if (rating5 && rating == 5)
                {
                    actualReviews.Add(review);
                }
            });

            return actualReviews;
        }

        private List<Review> getReviewByDate(List<Review> reviews, bool date1, bool date2, bool date3, bool date4)
        {
            List<Review> actualReviews = new List<Review>();

            reviews.ForEach(review =>
            {
                int month = review.dateTravel.Month;
                if (date1 && Util.belongNumberToInterval(month, 1, 3))
                {
                    actualReviews.Add(review);
                }
                else if (date2 && Util.belongNumberToInterval(month, 4, 6))
                {
                    actualReviews.Add(review);
                }
                else if (date3 && Util.belongNumberToInterval(month, 7, 9))
                {
                    actualReviews.Add(review);
                }
                else if (date4 && Util.belongNumberToInterval(month, 10, 12))
                {
                    actualReviews.Add(review);
                }
            });

            return actualReviews;
        }

        private List<Review> getReviewByTextSearch(List<Review> reviews, string textSearch)
        {
            if (textSearch == null || textSearch.ToLower().Trim().Length == 0)
            {
                return reviews;
            }
            textSearch = textSearch.ToLower().Trim();

            List<Review> actualReview = new List<Review>();
            reviews.ForEach(review =>
            {
                string name = review.header.ToLower().Trim();
                string description = review.description.ToLower().Trim();

                if (name.Contains(textSearch) || description.Contains(textSearch))
                {
                    actualReview.Add(review);
                }
            });

            return actualReview;
        }

        public async Task<ActionResult> AddPhoto(List<IFormFile> photo, int restaurantId)
        {
            if (photo.Count == 0)
            {
                return RedirectToAction("Index", "Restaurant", new { id = restaurantId });
            }

            List<Photo> photos = new List<Photo>();
            photo.ForEach(photo => photos.Add(new Photo { image = Util.getByteImage(photo), name = Util.getRandomNamePhoto(photo.FileName) }));
            await homeService.savePhotos(photos);

            Restaurant restaurant = await homeService.getRestaurantById(restaurantId);
            await homeService.changeRestaurantPhoto(restaurant, photos);

            return RedirectToAction("Index", "Restaurant", new { id = restaurantId });
        }
    }
}
