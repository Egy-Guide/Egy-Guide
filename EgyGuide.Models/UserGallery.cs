using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyGuide.Models
{
    public class UserGallery
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string ImageURL { get; set; }

        [Required]
        [NotMapped]
        public IFormCollection Images { get; set; }
    }
}
