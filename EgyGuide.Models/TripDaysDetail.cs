using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class TripDaysDetail
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        [ForeignKey("TripId")]
        public TripDetail TripDetail { get; set; }
        public int DayNum { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

    }
}
