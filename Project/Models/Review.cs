using System.ComponentModel.DataAnnotations;

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
    }
}
