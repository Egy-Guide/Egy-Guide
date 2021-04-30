using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class Guide
    {
        [Key]
        public int GuideId { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        
        [Required]
        public string IdentityCard { get; set; }
        [Required]
        public string Languages { get; set; }
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public int YearExperinces { get; set; }
        public float PricePerHour { get; set; }
        public float Rate { get; set; }
        public string face_link { get; set; }
        public string twitter_link { get; set; }
        public string insta_link { get; set; }
        public string youtube_link { get; set; }
        public string Remark { get; set; }


    }
}
