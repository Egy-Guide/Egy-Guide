using System.ComponentModel.DataAnnotations;

namespace EgyGuide.Models
{
    public class ServiceArea
    {
        [Key]
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int GuideId { get; set; }

        public Guide Guide { get; set; }
    }
}
