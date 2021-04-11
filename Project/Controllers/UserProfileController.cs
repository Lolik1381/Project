using Microsoft.AspNetCore.Mvc;
using Project.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class UserProfileController : Controller
    {
        ApplicationContext applicationContext;

        public UserProfileController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public string Index(int id)
        {
            return $"{id} index";
        }
    }
}
