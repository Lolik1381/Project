﻿using Microsoft.AspNetCore.Mvc;
using Project.Models;
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

        public ActionResult Index(int id)
        {
            Direction direction = homeService.getDirectionById(id);
            if (direction == null)
            {
                return LocalRedirect("~/");
            }

            Random random = new Random();
            ViewBag.galleryPhotos = new List<Photo>
        {
                direction.photos[random.Next(direction.photos.ToArray().Length)],
                direction.photos[random.Next(direction.photos.ToArray().Length)],
                direction.photos[random.Next(direction.photos.ToArray().Length)]
            };
            ViewBag.landmarks = direction.landmarks;
            ViewBag.hotel = direction.hotels;
            ViewBag.restaurant = direction.restaurants;
            ViewBag.name = direction.name;
            ViewBag.shortDescription = direction.shortDescription;
            ViewBag.description = direction.description;
            ViewBag.isUserAuthorization = DefaultSettings.isAuthorization;

            return View();
        }
    }
}
