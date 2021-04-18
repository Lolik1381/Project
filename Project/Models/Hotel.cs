using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Hotel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string hrefSite { get; set; }

        [Required]
        public int countStars { get; set; }

        [Required]
        public string styleHotel { get; set; }

        [Required]
        public string languages { get; set; }

        [Required]
        public List<Photo> photos { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        public List<Review> reviews { get; set; }
    }
}