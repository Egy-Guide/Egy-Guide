using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class RequestedSelectedStyle
    {
        [Key]
        public int SelectedStyleId { get; set; }
        public int StyleId { get; set; }
        public TripStyle TripStyle { get; set; }
        public int TripId { get; set; }
        public Requested Requested { get; set; }
    }
}
