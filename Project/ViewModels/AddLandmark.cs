using Microsoft.AspNetCore.Http;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AddLandmark
    {
        [Required]
        [Display(Name = "Название достопримечательности")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Главное фото")]
        public IFormFile MainPhoto { get; set; }

        [Display(Name = "Фото")]
        public List<IFormFile> Photos { get; set; }

        public int DirectionId { get; set; }
        public Direction Direction { get; set; }
    }
}
