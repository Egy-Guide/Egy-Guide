using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models.ViewModels
{
    public class GuideUserVM
    {
        public GuideUser GuideUser { get; set; }
        public GuideUserDetails GuideUserDetails { get; set; }
        public IEnumerable<TripDetail> Trips { get; set; }
    }
}
