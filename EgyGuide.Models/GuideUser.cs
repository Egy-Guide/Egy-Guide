using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class GuideUser
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        
        [Required]
        public string ServiceArea { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string YearExperience { get; set; }
        public string IdentityCardUrl { get; set; }
        public double PricePerHour { get; set; }      
        public double Rating { get; set; }
        public int NumberOfTours { get; set; }
        public int NumberOfReviews { get; set; }
        public string FacebookProfile { get; set; }
        public string TwitterProfile { get; set; }
        public string InstagramProfile { get; set; }
        public string YoutubeProfile { get; set; }
        public string Remark { get; set; }
        
    }
}
