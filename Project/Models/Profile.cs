using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public int countPublications { get; set; }

        [ForeignKey("userInfoId")]
        public UserInfo userInfo { get; set; }

        public List<Photo> photos { get; set; } = new List<Photo>();
    }
}
