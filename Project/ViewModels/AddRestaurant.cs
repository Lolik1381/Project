using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AddRestaurant
    {
        [Required]
        [Display(Name = "Название отеля")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Название достопримечательности")]
        public string Location { get; set; }

        [Display(Name = "Название достопримечательности")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Название достопримечательности")]
        public string Description { get; set; }

        [Display(Name = "Название достопримечательности")]
        public string HrefSite { get; set; }

        [Required]
        [Display(Name = "Тип кухни")]
        public string TypeCuisine { get; set; }

        [Display(Name = "Специальное меню")]
        public string SpecialMenu { get; set; }

        [Display(Name = "Время приема пищи")]
        public string TimeEating { get; set; }

        [Required]
        [Display(Name = "Главное фото")]
        public IFormFile MainPhoto { get; set; }

        [Display(Name = "Фото")]
        public List<IFormFile> Photos { get; set; }

        [Display(Name = "Сервис")]
        public string Services { get; set; }

        [Required]
        public int DirectionId { get; set; }
    }
}
