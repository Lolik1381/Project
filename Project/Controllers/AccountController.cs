using Microsoft.AspNetCore.Mvc;
using Project.Context;
using Project.Data;
using Project.Models;
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

        public ActionResult Index(int userId)
        {
            User user = applicationContext.users.Where(u => u.id == userId).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile profile = applicationContext.profiles.Where(p => p.id == user.profileId).FirstOrDefault();
            Photo mainPhoto = applicationContext.photos.Where(p => p.id == profile.mainPhotoId).FirstOrDefault();
            UserInfo userInfo = applicationContext.userInfos.Where(u => u.id == profile.userInfoId).FirstOrDefault();

            ViewBag.name = profile.name;
            ViewBag.lastName = profile.lastName;
            ViewBag.countPublications = profile.countPublications;
            ViewBag.mainPhoto = mainPhoto.name;
            
            ViewBag.city = userInfo.city;
            ViewBag.country = userInfo.country;
            ViewBag.personalInformation = userInfo.personalInformation;
            ViewBag.hrefWebSite = userInfo.hrefWebSite;
            ViewBag.create = userInfo.create;

            return View();
        }
    }
}
