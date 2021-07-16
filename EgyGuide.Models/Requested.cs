using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class Requested
    {
        [Key]
        public int TripId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public float Budget { get; set; }
        [Required]
        public int Days { get; set; }
        [Required]
        public int Nights { get; set; }
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
       
        public string Transport { get; set; }
        public DateTime MeetingDate { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        
        public string SelcetedStyles { get; set; }
        [Required]
        public string SelectedLanguages { get; set; }

        public int NumTravellers { get; set; }
        public ICollection<RequestedInfo> RequestedInfo { get; set; }


    }
}
