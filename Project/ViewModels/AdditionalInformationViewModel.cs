using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class AdditionalInformationViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Город проживания")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Страна проживания")]
        public string Country { get; set; }

        [Display(Name = "Сайт")]
        public string Websity { get; set; }

        [Display(Name = "Подробнее о себе")]
        public string PersonalInformation { get; set; }
    }
}
