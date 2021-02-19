using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EgyGuide.Models.ViewModels
{
    public class OfferCreateVM
    {
        public IEnumerable<TripStyle> TripStyles { get; set; }
        public TripDetail TripDetail { get; set; }

        //public IEnumerable<SelectedStyle> SelectedStyles { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
       
        

    }
}
