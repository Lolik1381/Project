using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AddHotel
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
        [Display(Name = "Название достопримечательности")]
        public int CountStars { get; set; }

        [Display(Name = "Название достопримечательности")]
        public string StyleHotel { get; set; }

        [Display(Name = "Название достопримечательности")]
        public string Languages { get; set; }

        [Required]
        [Display(Name = "Главное фото")]
        public IFormFile MainPhoto { get; set; }

        [Display(Name = "Фото")]
        public List<IFormFile> Photos { get; set; }

        [Required]
        public List<int> roomEquipment { get; set; }

        [Required]
        public List<int> roomType { get; set; }

        [Required]
        public List<int> services { get; set; }

        [Required]
        public int DirectionId { get; set; }
    }
}
