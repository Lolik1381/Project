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

        public int userInfoId { get; set; }
        public UserInfo userInfo { get; set; }

        public int mainPhotoId { get; set; }
        public Photo mainPhoto { get; set; }
    }
}
