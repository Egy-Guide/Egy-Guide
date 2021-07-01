using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class TravellerDetails
    {
        [Key]
        public int TravellerId { get; set; }
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public TripBooking TripBooking { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Nationality { get; set; }
    }
}
