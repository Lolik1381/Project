using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }

        public int userId {get; set;}

        public User user { get; set; }

        [Required]
        public string header { get; set; }

        [Required]
        public decimal rating { get; set; }

        [Required]
        public string description { get; set; }

        public List<Photo> photos { get; set; } = new List<Photo>();
    }
}
