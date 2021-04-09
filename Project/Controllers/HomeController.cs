using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Context;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext applicationContext = new ApplicationContext();

        public ActionResult Index()
        {
            IEnumerable<User> users = applicationContext.users;
            ViewBag.Users = users;
            return View();
        }
    }
}
