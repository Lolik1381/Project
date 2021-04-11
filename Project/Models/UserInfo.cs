using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class UserInfo
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string country { get; set; }

        public string personalInformation { get; set; }

        public string hrefWebSite { get; set; }

        [Required]
        public DateTime create { get; set; }
    }
}
