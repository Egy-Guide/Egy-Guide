using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models.ViewModels
{
    public class TouristVM
    {
        //public ApplicationUser User { get; set; }
       
        public IEnumerable<Requested> Trips { get; set; }
    }
}
