using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Profile
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public UserInfo userInfo { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        public Photo backgroundPhoto { get; set; }
    }
}
