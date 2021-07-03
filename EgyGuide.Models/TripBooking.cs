using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class TripBooking
    {
        [Key]
        public int BookingId { get; set; }
        public int TripId { get; set; }
        [ForeignKey("TripId")]
        public TripDetail TripDetail { get; set; }
        public string TouristId { get; set; }
        [ForeignKey("TouristId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string BookingNo { get; set; }
        public DateTime BookingDate { get; set; }
        public string TransactionId { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime TripStart { get; set; }
        public DateTime TripEnd { get; set; }
        public int TravellersNo { get; set; }
        public double TotalPrice { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
