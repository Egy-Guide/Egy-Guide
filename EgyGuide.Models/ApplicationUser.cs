using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace EgyGuide.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public string ImageUrl { get; set; }
        
        public string City { get; set; }
       
        [Column(TypeName = "text")]
        public string Brief { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
