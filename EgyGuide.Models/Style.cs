namespace EgyGuide.Models
{
    public class Style
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public int TripId { get; set; }

        public TripDetail TripDetail { get; set; }
    }
}
