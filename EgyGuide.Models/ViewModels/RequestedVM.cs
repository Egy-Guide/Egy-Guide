using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models.ViewModels
{
    public class RequestedVM
    {
        public IEnumerable<TripStyle> TripStyles { get; set; }
        public IEnumerable<RequestedSelectedStyle> SelectedStyle { get; set; }
        public Requested Requested { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        public IEnumerable<RequestedInfo> RequestedInfos { get; set; }
    }
}
