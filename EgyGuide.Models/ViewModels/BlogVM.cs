using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models.ViewModels
{
    // For Create Blog Page
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
