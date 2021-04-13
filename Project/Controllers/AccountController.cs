using Microsoft.AspNetCore.Mvc;
using Project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        ApplicationContext applicationContext;

        public AccountController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public ActionResult Index(int id)
        {
            return View();
        }
    }
}
