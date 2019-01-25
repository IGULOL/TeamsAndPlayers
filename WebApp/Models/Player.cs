using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(20, 65)]
        public int Age { get; set; }

        [Required]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}