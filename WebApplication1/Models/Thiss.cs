using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Thiss
    {
        public int ThisId { get; set; }
        public string Name { get; set; }
        public string Descc { get; set; }
        public string Img { get; set; }
        public int? SubClassId { get; set; }
        public int? CategoryId { get; set; }
        //public virtual Kingdoms Kingdoms { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubClass SubClass { get; set; }
    }
}
