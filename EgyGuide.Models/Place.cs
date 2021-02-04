namespace EgyGuide.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public int TripId { get; set; }
        public TripDetail TripDetail { get; set; }
    }
}
