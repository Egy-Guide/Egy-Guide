using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class TripDetail
    {
        [Key]
        public int TripId { get; set; }
        public int GuideId { get; set; }
        [ForeignKey("GuideId")]
        public Guide Guide { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public string Title { get; set; }
        public ICollection<Place> SelectedPlaces { get; set; }
        public int Days { get; set; }
        public int Nights { get; set; }
        public string Transport { get; set; }
        public string MeetingPlace { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Price { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
        public ICollection<Tag> SelectedTags { get; set; }
        public ICollection<Style> SelectedStyles { get; set; }
        public ICollection<Language> SelectedLanguages { get; set; }
        public int MaxTravellers { get; set; }
        public ICollection<Gallery> SelectedImages { get; set; }



    }
}
