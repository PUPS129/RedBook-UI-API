using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Kingdoms
    {
        public Kingdoms()
        {
            ClassA = new HashSet<ClassA>();
        }

        public int KingdomId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClassA> ClassA { get; set; }
    }
}
