using Microsoft.AspNetCore.Http;
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
            ViewBag.mainPhoto = mainPhoto.image;
            
            ViewBag.city = userInfo.city;
            ViewBag.country = userInfo.country;
            ViewBag.personalInformation = userInfo.personalInformation;
            ViewBag.hrefWebSite = userInfo.hrefWebSite;
            ViewBag.create = userInfo.create.ToShortDateString();

            return View();
        }

        [HttpPost]
        public ActionResult EditAccount(IFormFile backgroundAccauntPhoto, string name, string homePlace, string website, string personalInformation)
        {
            User user = applicationContext.users.Where(u => u.id.Equals(DefaultSettings.userId)).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Profile userProfile = applicationContext.profiles.Where(p => p.id.Equals(user.profileId)).FirstOrDefault();
            UserInfo userInfo = applicationContext.userInfos.Where(userInfo => userInfo.id.Equals(userProfile.userInfoId)).FirstOrDefault();

            if (backgroundAccauntPhoto != null)
            {
                Random random = new Random();
                string fileName = $"~/img/{System.IO.Path.GetFileName(backgroundAccauntPhoto.FileName)}";
                while (applicationContext.photos.Where(p => p.name.Equals(fileName)).FirstOrDefault() != null)
                {
                    fileName = $"{fileName}{random.Next()}";
                }

                applicationContext.photos.Add(new Photo { name = fileName, image = Util.getByteImage(backgroundAccauntPhoto) });
                applicationContext.SaveChanges();

/*                applicationContext.photos.Remove(applicationContext.photos.Where(p => p.id.Equals(userProfile.mainPhotoId)).FirstOrDefault());
                applicationContext.SaveChanges();*/

                int photoId = applicationContext.photos.Where(p => p.name.Equals(fileName)).First().id;
                userProfile.mainPhotoId = photoId;
                applicationContext.SaveChanges();
            }

            if (name != null)
            {
                string[] fullName = name.Split(" ");
                if (fullName.Length == 2 && fullName[0].Length > 2)
                {
                    userProfile.name = fullName[0];
                    userProfile.lastName = fullName[1];
                    applicationContext.SaveChanges();
                }
            }

            if (homePlace != null)
            {
                string[] home = homePlace.Split(",");
                userInfo.city = home[0];
                userInfo.country = home[1];
                applicationContext.SaveChanges();
            }

            if (website != null)
            {
                userInfo.hrefWebSite = website;
                applicationContext.SaveChanges();
            }

            if (personalInformation != null)
            {
                userInfo.personalInformation = personalInformation;
                applicationContext.SaveChanges();
            }

            return LocalRedirect($"~/Account?userId={DefaultSettings.userId}");
        }
    }
}
