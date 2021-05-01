using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class Excluded
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public string Title { get; set; }
        public ICollection<TripDetail> TripDetails { get; set; }
    }
}
