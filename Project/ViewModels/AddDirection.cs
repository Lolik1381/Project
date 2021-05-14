using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AddDirection
    {
        [Required]
        [Display(Name = "Название направления")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Главное фото")]
        public IFormFile MainPhoto { get; set; }

        [Display(Name = "Фото")]
        public List<IFormFile> Photos { get; set; }
    }
}
