﻿using Microsoft.AspNetCore.Authorization;
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
    public class ReviewController : Controller
    {
        IHomeService homeService;
        readonly UserManager<User> userManager;

        public ReviewController(IHomeService homeService, UserManager<User> userManager)
        {
            this.homeService = homeService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<ActionResult> Index(string searchText)
        {
            User user = await homeService.getUserById(userManager.GetUserId(User));

            ViewBag.reviewInformation = await Search(searchText);
            ViewBag.photoProfile = user.profile.mainPhoto;
            ViewBag.hrefUserProfile = $"/Account?userId={user?.Id}";

            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Review(int id, string type)
        {
            if (id == 0)
            {
                return null;
            }

            if (!type.Equals("Landmark") && !type.Equals("Restaurant") && !type.Equals("Hotel"))
            {
                throw new Exception("Не верный тип привязки отзыва!");
            }

            User user = await homeService.getUserById(userManager.GetUserId(User));
            Landmark landmark = type.Equals("Landmark") ? await homeService.getLandmarkById(id) : null;
            Hotel hotel = type.Equals("Hotel") ? await homeService.getHotelById(id) : null;
            Restaurant restaurant = type.Equals("Restaurant") ? await homeService.getRestaurantById(id) : null;

            ReviewInformationModel review = new ReviewInformationModel();
            if (landmark != null)
            {
                review.mainPhoto = landmark.mainPhoto;
                review.name = landmark.name;
                review.place = null;
                review.id = landmark.id;
                review.type = type;
            } 
            else if (hotel != null)
            {
                review.mainPhoto = hotel.mainPhoto;
                review.name = hotel.name;
                review.place = null;
                review.id = hotel.id;
                review.type = type;
            }
            else if (restaurant != null)
            {
                review.mainPhoto = restaurant.mainPhoto;
                review.name = restaurant.name;
                review.place = null;
                review.id = restaurant.id;
                review.type = type;
            }

            ViewBag.reviewInformation = new List<ReviewInformationModel> { review };
            ViewBag.photoProfile = user.profile.mainPhoto;
            ViewBag.hrefUserProfile = $"/Account?userId={user?.Id}";
            ViewBag.type = type;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Review(ReviewModel reviewModel)
        {
            string userId = userManager.GetUserId(User);
            User user = await homeService.getUserById(userId);

            List<Photo> photos = new List<Photo>();
            if (reviewModel.Files != null)
            {
                reviewModel.Files.ForEach(file => photos.Add(new Photo { image = Util.getByteImage(file), name = file.FileName }));
            }
            await homeService.savePhotos(photos);

            Review review = new Review
            {
                user = user,
                header = reviewModel.Name,
                rating = reviewModel.Rating,
                description = reviewModel.Description,
                created = DateTime.Now,
                dateTravel = reviewModel.Date,
                hotelId = reviewModel.Type.Equals("Hotel") ? reviewModel.Id : null,
                landmarkId = reviewModel.Type.Equals("Landmark") ? reviewModel.Id : null,
                restaurantId = reviewModel.Type.Equals("Restaurant") ? reviewModel.Id : null,
                photos = photos
            };
            await homeService.saveReview(review);

            if (reviewModel.Type.Equals("Hotel"))
            {
                Hotel hotel = await homeService.getHotelById(reviewModel.Id);
                await homeService.changeHotelReview(hotel, review);
            } 
            else if (reviewModel.Type.Equals("Landmark"))
            {
                Landmark landmark = await homeService.getLandmarkById(reviewModel.Id);
                await homeService.changeLandmarkReview(landmark, review);
            }
            else if (reviewModel.Type.Equals("Restaurant"))
            {
                Restaurant restaurant = await homeService.getRestaurantById(reviewModel.Id);
                await homeService.changeRestaurantReview(restaurant, review);
            }

            return Redirect($"~/{reviewModel.Type}/Index/{reviewModel.Id}");
        }

        private async Task<List<ReviewInformationModel>> Search(string searchText)
        {
            if (searchText == null)
            {
                return await Search();
            }

            searchText = searchText.ToLower().Trim();

            List<Hotel> hotels = await homeService.getHotels();
            List<Restaurant> restaurants = await homeService.getRestaurants();
            List<Landmark> landmarks = await homeService.getLandmarks();

            List<ReviewInformationModel> reviewInformation = new List<ReviewInformationModel>();
            if (hotels != null)
            {
                List<Hotel> searchHotels = hotels.Where(hotel => hotel.name.ToLower().Contains(searchText)).ToList();
                if (searchHotels != null)
                {
                    searchHotels.ForEach(hotel => reviewInformation.Add(new ReviewInformationModel 
                    { 
                        mainPhoto = hotel.mainPhoto, 
                        name = hotel.name, 
                        place = null,
                        id = hotel.id,
                        type = "Hotel"
                    }));
                }
            }
            if (restaurants != null)
            {
                List<Restaurant> searchRestaurants = restaurants.Where(restaurant => restaurant.name.ToLower().Contains(searchText)).ToList();
                if (searchRestaurants != null)
                {
                    searchRestaurants.ForEach(restaurant => reviewInformation.Add(new ReviewInformationModel 
                    { 
                        mainPhoto = restaurant.mainPhoto, 
                        name = restaurant.name, 
                        place = null,
                        id = restaurant.id,
                        type = "Restaurant"
                    }));
                }
            }
            if (landmarks != null)
            {
                List<Landmark> searchLandmark = landmarks.Where(landmark => landmark.name.ToLower().Contains(searchText)).ToList();
                if (searchLandmark != null)
                {
                    searchLandmark.ForEach(landmark => reviewInformation.Add(new ReviewInformationModel 
                    { 
                        mainPhoto = landmark.mainPhoto, 
                        name = landmark.name, 
                        place = null,
                        id = landmark.id,
                        type = "Landmark"
                    }));
                }
            }

            return reviewInformation;
        }

        private async Task<List<ReviewInformationModel>> Search()
        {
            List<Hotel> hotels = await homeService.getHotels();
            List<Restaurant> restaurants = await homeService.getRestaurants();
            List<Landmark> landmarks = await homeService.getLandmarks();

            List<ReviewInformationModel> reviewInformation = new List<ReviewInformationModel>();
            if (hotels != null)
            {
                hotels.ForEach(hotel => reviewInformation.Add(new ReviewInformationModel 
                { 
                    mainPhoto = hotel.mainPhoto, 
                    name = hotel.name, 
                    place = null,
                    id = hotel.id,
                    type = "Hotel"
                }));
            }
            if (restaurants != null)
            {
                restaurants.ForEach(restaurant => reviewInformation.Add(new ReviewInformationModel 
                { 
                    mainPhoto = restaurant.mainPhoto, 
                    name = restaurant.name, 
                    place = null,
                    id = restaurant.id,
                    type = "Restaurant"
                }));
            }
            if (landmarks != null)
            {
                landmarks.ForEach(landmark => reviewInformation.Add(new ReviewInformationModel 
                { 
                    mainPhoto = landmark.mainPhoto, 
                    name = landmark.name, 
                    place = null,
                    id = landmark.id,
                    type = "Landmark"
                }));
            }

            return reviewInformation;
        }
    }
}