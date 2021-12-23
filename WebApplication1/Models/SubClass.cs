using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SubClass
    {
        public SubClass()
        {
            Thiss = new HashSet<Thiss>();
        }

        public int SubClassId { get; set; }
        public string Name { get; set; }
        public int? ClassId { get; set; }

        public virtual ClassA Class { get; set; }
        public virtual ICollection<Thiss> Thiss { get; set; }
    }
}
