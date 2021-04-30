using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.Models
{
    public class TripStyle
    {
        [Key]
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public string ClassName { get; set; }
        public bool IsChecked { get; set; } = false;
        public ICollection<SelectedStyle> SelectedStyle { get; set; }
    }
}
