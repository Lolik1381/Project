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

        public ReviewController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public async Task<ActionResult> Index(string searchText)
        {
            ViewBag.reviewInformation = await Search(searchText);
            return View();
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
                    searchHotels.ForEach(hotel => reviewInformation.Add(new ReviewInformationModel { mainPhoto = hotel.mainPhoto, name = hotel.name, place = null }));
                }
            }
            if (restaurants != null)
            {
                List<Restaurant> searchRestaurants = restaurants.Where(restaurant => restaurant.name.ToLower().Contains(searchText)).ToList();
                if (searchRestaurants != null)
                {
                    searchRestaurants.ForEach(restaurant => reviewInformation.Add(new ReviewInformationModel { mainPhoto = restaurant.mainPhoto, name = restaurant.name, place = null }));
                }
            }
            if (landmarks != null)
            {
                List<Landmark> searchLandmark = landmarks.Where(landmark => landmark.name.ToLower().Contains(searchText)).ToList();
                if (searchLandmark != null)
                {
                    searchLandmark.ForEach(landmark => reviewInformation.Add(new ReviewInformationModel { mainPhoto = landmark.mainPhoto, name = landmark.name, place = null }));
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
                hotels.ForEach(hotel => reviewInformation.Add(new ReviewInformationModel { mainPhoto = hotel.mainPhoto, name = hotel.name, place = null }));
            }
            if (restaurants != null)
            {
                restaurants.ForEach(restaurant => reviewInformation.Add(new ReviewInformationModel { mainPhoto = restaurant.mainPhoto, name = restaurant.name, place = null }));
            }
            if (landmarks != null)
            {
                landmarks.ForEach(landmark => reviewInformation.Add(new ReviewInformationModel { mainPhoto = landmark.mainPhoto, name = landmark.name, place = null }));
            }

            return reviewInformation;
        }
    }
}
