using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Landmark
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        public List<Photo> photos { get; set; }

        public decimal rating { get; set; }

        public List<Review> reviews { get; set; }

        [Required]
        public string location { get; set; }

        public string phoneNumber { get; set; }

        public string description { get; set; }

        public string webSite { get; set; }
    }
}
