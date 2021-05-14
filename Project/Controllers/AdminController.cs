using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Service;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        readonly UserManager<User> userManager;
        readonly SignInManager<User> signInManager;
        IHomeService applicationService;

        public AdminController(IHomeService applicationService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.applicationService = applicationService;
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Index()
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> AddDirection()
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> AddDirection(AddDirection model)
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            Direction direction = new Direction
            {
                name = model.Name,
                shortDescription = model.ShortDescription,
                description = model.ShortDescription,
                mainPhoto = Util.getPhotoByImage(model.MainPhoto),
                photos = Util.getPhotosByImage(model.Photos),
                landmarks = new List<Landmark>(),
                hotels = new List<Hotel>(),
                restaurants = new List<Restaurant>()
            };
            await applicationService.saveDirection(direction);

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> AddLandmark()
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            List<Direction> directions = await applicationService.getDirections();
            SelectList selectList = new SelectList(directions, "id", "name");
            ViewBag.selectList = selectList;

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> AddLandmark(AddLandmark model)
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            Landmark landmark = new Landmark
            {
                name = model.Name,
                mainPhoto = Util.getPhotoByImage(model.MainPhoto),
                photos = Util.getPhotosByImage(model.Photos)
            };
            await applicationService.saveLandmark(landmark);

            await applicationService.changeDirectionLandmark(await applicationService.getDirectionById(model.DirectionId), landmark);

            return LocalRedirect($"~/Admin/AddDirection");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> AddHotel()
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            List<Direction> directions = await applicationService.getDirections();
            List<RoomEquipment> roomEquipments = await applicationService.getRoomEquipments();
            List<RoomType> roomTypes = await applicationService.getRoomType();
            List<Services> services = await applicationService.getServices();

            ViewBag.selectRoomEquipments = new SelectList(roomEquipments, "id", "name");
            ViewBag.selectRoomTypes = new SelectList(roomTypes, "id", "name"); 
            ViewBag.selectServices = new SelectList(services, "id", "name");
            ViewBag.selectDirection = new SelectList(directions, "id", "name");

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> AddHotel(AddHotel model)
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            List<RoomEquipment> currentRoomEquipments = new List<RoomEquipment>();
            List<RoomType> currentRoomTypes = new List<RoomType>();
            List<Services> currentServices = new List<Services>();

            foreach(var id in model.roomEquipment)
            {
                currentRoomEquipments.Add(await applicationService.getRoomEquipmentById(id));
            }
            foreach (var id in model.roomType)
            {
                currentRoomTypes.Add(await applicationService.getRoomTypeById(id));
            }
            foreach (var id in model.services)
            {
                currentServices.Add(await applicationService.getServicesById(id));
            }

            Hotel hotel = new Hotel
            {
                name = model.Name,
                location = model.Location,
                phoneNumber = model.PhoneNumber,
                description = model.Description,
                hrefSite = model.HrefSite,
                countStars = model.CountStars,
                styleHotel = model.StyleHotel,
                languages = model.Languages,
                photos = Util.getPhotosByImage(model.Photos),
                mainPhoto = Util.getPhotoByImage(model.MainPhoto),
                roomEquipment = currentRoomEquipments,
                roomType = currentRoomTypes,
                services = currentServices
            };
            await applicationService.saveHotel(hotel);
            await applicationService.changeDirectionHotel(await applicationService.getDirectionById(model.DirectionId), hotel);

            return LocalRedirect($"~/Admin/AddDirection");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> AddRestaurant()
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            List<Direction> directions = await applicationService.getDirections();
            ViewBag.selectDirection = new SelectList(directions, "id", "name");

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> AddRestaurant(AddRestaurant model)
        {
            ViewBag.defaultLoginImage = await applicationService.getPhotoByName("defaultLoginImage");
            ViewBag.defaultSityImage = await applicationService.getPhotoByName("defaultSityImage");

            Restaurant restaurant = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g150807-d787079-Reviews-Lorenzillo_s-Cancun_Yucatan_Peninsula.html
                name = model.Name,
                location = model.Location,
                phone = model.PhoneNumber,
                webSite = model.HrefSite,
                typeCuisine = model.TypeCuisine,
                specialMenu = model.SpecialMenu,
                timeEating = model.TimeEating,
                services = model.Services,
                mainPhoto = Util.getPhotoByImage(model.MainPhoto),
                photos = Util.getPhotosByImage(model.Photos)
            };
            await applicationService.saveRestaurant(restaurant);
            await applicationService.changeDirectionRestaurant(await applicationService.getDirectionById(model.DirectionId), restaurant);

            return LocalRedirect($"~/Admin/AddDirection");
        }
    }
}