using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Restaurant
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string location { get; set; }

        public string phone { get; set; }

        public string webSite { get; set; }

        [Required]
        public List<Photo> photos { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        [Required]
        public string typeCuisine { get; set; }

        public string specialMenu { get; set; }

        public decimal rating { get; set; }

        public List<Review> reviews { get; set; }
    }
}