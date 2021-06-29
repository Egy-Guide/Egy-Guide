﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public int TripId { get; set; }
        public string URL { get; set; }
        public ICollection<TripDetail> TripDetails { get; set; }


    }
}
