using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Direction
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string shortDescription { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        public List<Photo> photos { get; set; }

        [Required]
        public List<Landmark> landmarks { get; set; }
    }
}
