using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public Profile profile { get; set; }
    }
}