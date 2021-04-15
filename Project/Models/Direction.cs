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

        public int mainPhotoId { get; set; }
        public Photo mainPhoto { get; set; }
    }
}
