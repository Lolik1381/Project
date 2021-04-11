using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string login { get; set; }

        [Required]
        public string password { get; set; }

        [ForeignKey("profileId")]
        public Profile profile { get; set; }
    }
}