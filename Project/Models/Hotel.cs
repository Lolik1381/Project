using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Hotel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string location { get; set; }

        public string phoneNumber { get; set; }

        public string description { get; set; }

        public string hrefSite { get; set; }

        [Required]
        public int countStars { get; set; }

        public string styleHotel { get; set; }

        [Required]
        public string languages { get; set; }

        [Required]
        public List<Photo> photos { get; set; }

        [Required]
        public Photo mainPhoto { get; set; }

        public decimal rating { get; set; }

        public List<Review> reviews { get; set; }

        [Required]
        public List<RoomEquipment> roomEquipment { get; set; }

        [Required]
        public List<RoomType> roomType { get; set; }

        [Required]
        public List<Services> services { get; set; }
    }
}