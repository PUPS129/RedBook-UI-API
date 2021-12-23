using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Category
    {
        public Category()
        {
            Thiss = new HashSet<Thiss>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Descc { get; set; }

        public virtual ICollection<Thiss> Thiss { get; set; }
    }
}
