using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public int TripId { get; set; }
        public TripDetail TripDetail { get; set; }
        public string URL { get; set; }

      
    }
}
