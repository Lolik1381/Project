using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class DirectionLandmarkLink
    {
        [Key]
        public int id { get; set; }

        public int directionId { get; set; }
        public Direction direction { get; set; }

        public int landmarkId { get; set; }
        public Landmark landmark { get; set; }
    }
}
