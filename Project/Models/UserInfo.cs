using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class UserInfo
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string placeResidence { get; set; }

        public string personalInformation { get; set; }

        public string hrefWebSite { get; set; }

        [Required]
        public DateTime create { get; set; }
    }
}
