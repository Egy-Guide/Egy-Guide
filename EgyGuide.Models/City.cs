﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}