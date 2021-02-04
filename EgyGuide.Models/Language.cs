using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class Language
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int TripId { get; set; }

        public TripDetail TripDetail { get; set; }
    }
}
