using Microsoft.AspNetCore.Mvc;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class LandmarkController : Controller
    {
        IHomeService homeService;

        public LandmarkController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public string Index(int id)
        {
            return $"Landmark {id}";
        }
    }
}
