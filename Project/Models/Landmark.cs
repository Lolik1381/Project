using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<Photo> photos { get; set; } = new List<Photo>();

        public List<Review> reviews { get; set; } = new List<Review>();

    }
}
