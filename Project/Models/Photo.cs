using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Photo
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public byte[] image { get; set; }
    }
}
