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

        [Required]
        public string phone { get; set; }

        [Required]
        public string webSite { get; set; }

        [Required]
        public List<Photo> photos { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        [Required]
        public string typeCuisine { get; set; }

        [Required]
        public string service { get; set; }

        public List<Review> reviews { get; set; }
    }
}