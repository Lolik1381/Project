using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ReviewPhotoLink
    {
        [Key]
        public int id { get; set; }

        public int reviewId { get; set; }
        public Review review { get; set; }

        public int photoId { get; set; }
        public Photo photo { get; set; }
    }
}
