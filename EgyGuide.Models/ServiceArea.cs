namespace EgyGuide.Models
{
    public class ServiceArea
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int GuideId { get; set; }

        public Guide Guide { get; set; }
    }
}
