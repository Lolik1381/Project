using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class LandmarkReviewLink
    {
        [Key]
        public int id { get; set; }

        public int landmarkId { get; set; }
        public Landmark landmark { get; set; }

        public int reviewId { get; set; }
        public Review review { get; set; }
    }
}
