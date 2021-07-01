using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models.ViewModels
{
    public class BookingVM
    {
        public TripDetail TripDetail { get; set; }
        public TripBooking TripBooking { get; set; }
        public List<TravellerDetails> TravellersDetails { get; set; }
    }
}
