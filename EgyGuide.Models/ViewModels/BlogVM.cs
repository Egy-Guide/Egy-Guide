using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models.ViewModels
{
    // For Blog Index Page
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
