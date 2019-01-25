﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual List<Player> Players { get; set; }
    }
}