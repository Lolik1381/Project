using Microsoft.AspNetCore.Mvc;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class DirectionController : Controller
    {
        private IHomeService homeService;

        public DirectionController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Index(int idDirection)
        {
            return View();
        }
    }
}
