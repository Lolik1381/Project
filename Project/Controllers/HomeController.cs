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

            new DefaultData(applicationContext).createDefaultData();
        }

        public ActionResult Index()
        {
            List<Direction> directions = applicationContext.directions.ToList();
            ViewBag.directions = directions;

            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            User user = applicationContext.users.Where(u => u.login.Equals(login) && u.password.Equals(password)).FirstOrDefault();

            return user != null
                ? RedirectToAction("Index", "UserProfile", new { userId = user.id })
                : LocalRedirect("~/");
        }

        [HttpPost]
        public IActionResult Authorization()
        {
            return null;
        }
    }
}
