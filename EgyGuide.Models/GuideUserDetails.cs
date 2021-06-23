using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class GuideUserDetails
    {
        [Key]
        public int Id { get; set; }
        public int GuideId { get; set; }
        [ForeignKey("GuideId")]
        public GuideUser GuideUser { get; set; }
        public string Introduction { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PrivateTransportation { get; set; }
        public string PublicTransportation { get; set; }
        public string MoreDetails { get; set; }
        public string CertificateUrl { get; set; }
        public string SpecialRemark { get; set; }
        public DateTime Birthday { get; set; }

        [NotMapped]
        public IFormFile CertificateImage { get; set; }
    }
}
