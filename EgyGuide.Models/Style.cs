using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class Style
    {
        [Key]
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public int TripId { get; set; }

        public TripDetail TripDetail { get; set; }
    }
}
