using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }

        [Required]
        public User user { get; set; }

        [Required]
        public string header { get; set; }

        [Required]
        public decimal rating { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public DateTime created { get; set; } 

        [Required]
        public DateTime dateTravel { get; set; }

        public List<Photo> photos { get; set; }

        public int? hotelId { get; set; }

        public int? landmarkId { get; set; }

        public int? restaurantId { get; set; }
    }
}
