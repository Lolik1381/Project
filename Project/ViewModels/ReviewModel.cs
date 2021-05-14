using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class ReviewModel
    {
        [Required]
        [Display(Name = "Балл")]
        [Range(1, 5, ErrorMessage = "Необходимо указать рейтинг")]
        public decimal Rating { get; set; }

        [Required]
        [Display(Name = "Оставить отзыв (обязательно)")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Добавить название отзыва (обязательно)")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Когда Вы ездили? (обязательно)")]
        public DateTime Date { get; set; }

        [Display(Name = "Фото")]
        public List<IFormFile> Files { get; set; }

        [HiddenInput]
        public string Type { get; set; }

        [HiddenInput]
        public int Id { get; set; }
    }
}
