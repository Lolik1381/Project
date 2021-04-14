using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Direction
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string shortDescription { get; set; }

        [Required]
        public string description { get; set; }

        //[Required]
        public List<Photo> photos { get; set; } = new List<Photo>();

        /*[ForeignKey("PhotoId")]*/
        public int mainPhotoId { get; set; }
        public Photo mainPhoto { get; set; }

        [ForeignKey("LandmarksId")]
        public List<Landmark> landmarks { get; set; } = new List<Landmark>();
    }
}
