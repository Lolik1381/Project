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
        public decimal rating { get; set; }

        [Required]
        public List<Photo> photos { get; set; }

        public List<Review> reviews { get; set; }
    }
}
