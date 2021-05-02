using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class DirectionController : Controller
    {
        private IHomeService homeService;
        private UserManager<User> userManager;

        public DirectionController(IHomeService homeService, UserManager<User> userManager)
        {
            this.homeService = homeService;
            this.userManager = userManager;
        }

        public ActionResult Index(int id)
        {
            Direction direction = homeService.getDirectionById(id);
            User user = userManager.GetUserAsync(User).Result;
            if (direction == null)
            {
                return LocalRedirect("~/");
            }

            List<Photo> allPhoto = new List<Photo>();
            allPhoto.Add(direction.mainPhoto);
            allPhoto.AddRange(direction.photos);
            direction.landmarks.ForEach(l => allPhoto.Add(l.mainPhoto));
            direction.landmarks.ForEach(l => allPhoto.AddRange(l.photos));
            direction.hotels.ForEach(h => allPhoto.Add(h.mainPhoto));
            direction.hotels.ForEach(h => allPhoto.AddRange(h.photos));
            direction.restaurants.ForEach(r => allPhoto.Add(r.mainPhoto));
            direction.restaurants.ForEach(r => allPhoto.AddRange(r.photos));

            Random random = new Random();
            ViewBag.galleryPhotos = new List<Photo>
            {
                allPhoto[random.Next(allPhoto.Count)],
                allPhoto[random.Next(allPhoto.Count)],
                allPhoto[random.Next(allPhoto.Count)]
            };
            ViewBag.landmarks = direction.landmarks;
            ViewBag.hotel = direction.hotels;
            ViewBag.restaurant = direction.restaurants;
            ViewBag.name = direction.name;
            ViewBag.shortDescription = direction.shortDescription;
            ViewBag.description = direction.description;
            ViewBag.hrefUserProfile = "/Account?userId=" + user?.Id;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.photoProfile = homeService.getUserById(userManager.GetUserId(User)).Result.profile.mainPhoto;
            }

            return View();
        }
    }
}
