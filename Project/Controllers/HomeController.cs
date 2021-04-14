using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Context;
using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext applicationContext;

        public HomeController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;

            if (DefaultSettings.isFirstData)
            {
                new DefaultData(applicationContext).createDefaultData();
            }
        }

        public ActionResult Index()
        {
            List<Direction> directions = applicationContext.directions.ToList();
            foreach(Direction d in directions)
            {
                d.mainPhoto = applicationContext.photos.Where(p => p.id == d.mainPhotoId).FirstOrDefault();
            }

            ViewBag.directions = directions;
            ViewBag.isUserAuthorization = DefaultSettings.isAuthorization;
            ViewBag.hrefUserProfile = "/Account?userId=" + DefaultSettings.userId;

            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            User user = applicationContext.users.Where(u => u.login.Equals(login) && u.password.Equals(password)).FirstOrDefault();

            if (user != null)
            {
                DefaultSettings.isAuthorization = true;
                DefaultSettings.userId = user.id;
                return RedirectToAction("Index", "Account", new { userId = user.id });
            }
            return LocalRedirect("~/");
        }

        [HttpPost]
        public IActionResult Authorization()
        {
            return null;
        }
    }
}
