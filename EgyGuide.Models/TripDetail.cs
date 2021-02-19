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
        
        //public int GuideId { get; set; }
        //[ForeignKey("GuideId")]
        //public Guide Guide { get; set; }
       
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string SelectedPlaces { get; set; }

        [Required]
        public int Days { get; set; }
        [Required]
        public int Nights { get; set; }
        public string Transport { get; set; }
        public string MeetingPlace { get; set; }
        public DateTime MeetingDate { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        public string SelectedTags { get; set; }

        public string SelcetedStyles { get; set; }
        [Required]
        public string SelectedLanguages { get; set; }
        public int MaxTravellers { get; set; }
        
        
        
        
        public ICollection<Gallery> SelectedImages { get; set; }



    }
}
