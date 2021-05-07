using Microsoft.AspNetCore.Mvc;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class RestaurantController : Controller
    {
        IHomeService homeService;

        public RestaurantController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public string Index(int Id)
        {
            return $"Restaurant {Id}";
        }
    }
}
