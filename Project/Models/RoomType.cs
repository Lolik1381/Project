using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class RoomType
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public Photo photo { get; set; }

        [Required]
        public List<Hotel> hotelRoomType { get; set; }
    }
}
