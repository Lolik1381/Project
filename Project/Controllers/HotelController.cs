using Microsoft.AspNetCore.Mvc;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HotelController : Controller
    {
        IHomeService homeService;

        public HotelController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public string Index(int Id)
        {
            return $"Hotel {Id}";
        }
    }
}
