using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        [Required]
        public string PlaceName { get; set; }
        public int TripId { get; set; }
        public TripDetail TripDetail { get; set; }

    }
}
