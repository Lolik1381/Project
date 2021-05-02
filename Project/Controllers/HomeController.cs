using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Service;
using System;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
            this.homeService.startMigrationData();
        }

        public ActionResult Index()
        {
            List<Direction> directions = homeService.getDirections();

            ViewBag.directions = directions;
            ViewBag.isUserAuthorization = DefaultSettings.isAuthorization;
            ViewBag.hrefUserProfile = "/Account?userId=" + DefaultSettings.userId;
            if (DefaultSettings.isAuthorization)
            {
                ViewBag.photoProfile = homeService.getUserById(DefaultSettings.userId).profile.mainPhoto;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            User user = homeService.getUserByLoginAndPassword(login, password);

            if (user != null)
            {
                DefaultSettings.isAuthorization = true;
                DefaultSettings.userId = user.id;
                return RedirectToAction("Index", "Account", new { userId = user.id });
            }

            return LocalRedirect("~/");
        }

        [HttpPost]
        public IActionResult Authorization(string login, string password)
        {
            User user = homeService.getUserByLoginAndPassword(login, password);
            
            if (user != null)
            {
                return LocalRedirect("~/");
            }

            UserInfo userInfo = new UserInfo { create = DateTime.Now, placeResidence = "Место проживания" };
            Profile profile = new Profile { name = "Имя", lastName = "Фамилия", mainPhoto = homeService.getPhotoById(1), userInfo = userInfo };
            user = new User { login = login, password = password, profile = profile};
            homeService.saveUser(user);

            DefaultSettings.isAuthorization = true;
            DefaultSettings.userId = homeService.getUserByLogin(login).id;
            return LocalRedirect("~/#popup3");
        }
    }
}