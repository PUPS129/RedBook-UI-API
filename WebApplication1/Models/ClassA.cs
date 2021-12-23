using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ClassA
    {
        public ClassA()
        {
            SubClass = new HashSet<SubClass>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public int KingdomId { get; set; }

        public virtual Kingdoms Kingdom { get; set; }
        public virtual ICollection<SubClass> SubClass { get; set; }
    }
}
