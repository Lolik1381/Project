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
    }
}
