namespace EgyGuide.Models
{
    public class Language
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int TripId { get; set; }

        public TripDetail TripDetail { get; set; }
    }
}
