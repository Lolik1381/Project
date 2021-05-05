using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        readonly UserManager<User> userManager;
        IHomeService homeService;

        public HomeController(IHomeService homeService, UserManager<User> userManager)
        {
            this.homeService = homeService;
            this.userManager = userManager;
            this.homeService.startMigrationData();
        }

        public async Task<ActionResult> Index()
        {
            User user = await userManager.GetUserAsync(User);
            List<Direction> directions = await homeService.getDirections();

            ViewBag.directions = directions;
            ViewBag.hrefUserProfile = "/Account?userId=" + user?.Id;
            if (User.Identity.IsAuthenticated)
            {
                User userWithProfile = await homeService.getUserById(user.Id);
                ViewBag.photoProfile = userWithProfile.profile.mainPhoto;
            }

            return View();
        }
    }
}