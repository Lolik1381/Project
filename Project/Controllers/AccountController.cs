﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Data;
using Project.Models;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        IHomeService homeService;

        public AccountController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Index(int userId)
        {
            User user = homeService.getUserById(userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile profile = user.profile;
            List<Review> reviews = homeService.getReviewsByUserId(user.id);

            ViewBag.reviews = reviews;
            ViewBag.countPublications = reviews.ToArray().Length;

            ViewBag.name = profile.name;
            ViewBag.lastName = profile.lastName;
            ViewBag.mainPhoto = profile.mainPhoto.image;
            ViewBag.backgroundPhoto = profile.backgroundPhoto != null ? profile.backgroundPhoto.image : null;

            ViewBag.placeResidence = profile.userInfo.placeResidence;
            ViewBag.personalInformation = profile.userInfo.personalInformation;
            ViewBag.hrefWebSite = profile.userInfo.hrefWebSite;
            ViewBag.create = profile.userInfo.create.ToShortDateString();

            return View();
        }

        [HttpPost]
        public ActionResult EditAccount(IFormFile mainPhoto, string name, string homePlace, string website, string personalInformation)
        {
            User user = homeService.getUserById(DefaultSettings.userId);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile profile = user.profile;
            UserInfo userInfo = profile.userInfo;

            Photo profileMainPhoto = null;
            string profileName = null;
            string profileLastName = null;

            if (mainPhoto != null)
            {
                string photoName = $"~/img/{System.IO.Path.GetFileName(mainPhoto.FileName)}";

                homeService.savePhoto(new Photo { name = photoName, image = Util.getByteImage(mainPhoto) });
                profileMainPhoto = homeService.getPhotoByName(photoName);
            }

            if (name != null)
            {
                string[] fullName = name.Split(" ");
                if (fullName.Length == 2 && fullName[0].Length > 2)
                {
                    profileName = fullName[0];
                    profileLastName = fullName[1];
                }
            }

            homeService.changeProfile(profile, profileMainPhoto, profileName, profileLastName, null);
            homeService.changeUserInfo(userInfo, homePlace, website, personalInformation);

            return LocalRedirect($"~/Account?userId={DefaultSettings.userId}");
        }

        [HttpPost]
        public ActionResult Exit()
        {
            DefaultSettings.isAuthorization = false;
            DefaultSettings.userId = -1;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult BackgroundPhoto(IFormFile backgroundAccauntPhoto)
        {
            if (backgroundAccauntPhoto != null)
            {
                User user = homeService.getUserById(DefaultSettings.userId);
                string photoName = $"~/img/{System.IO.Path.GetFileName(backgroundAccauntPhoto.FileName)}";

                homeService.savePhoto(new Photo { name = photoName, image = Util.getByteImage(backgroundAccauntPhoto) });
                homeService.changeProfile(user.profile, null, null, null, homeService.getPhotoByName(photoName));
            }

            return LocalRedirect($"~/Account?userId={DefaultSettings.userId}");
        }
    }
}
