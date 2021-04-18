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

        public List<Photo> photos { get; set; }
    }
}
