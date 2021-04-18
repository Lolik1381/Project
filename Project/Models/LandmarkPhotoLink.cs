using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class LandmarkPhotoLink
    {
        [Key]
        public int id { get; set; }

        public int landmarkId { get; set; }
        public Landmark landmark { get; set; }

        public int photoId { get; set; }
        public Photo photo { get; set; }
    }
}
