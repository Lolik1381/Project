using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class DirectionPhotoLink
    {
        [Key]
        public int id { get; set; }

        public int directionId { get; set; }
        public Direction direction { get; set; }

        public int photoId { get; set; }
        public Photo photo { get; set; }
    }
}
