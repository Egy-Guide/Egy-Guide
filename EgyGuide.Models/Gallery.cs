namespace EgyGuide.Models
{
    public class Gallery
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int TripId { get; set; }

        public TripDetail TripDetail { get; set; }
    }
}
