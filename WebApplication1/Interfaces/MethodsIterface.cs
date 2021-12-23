using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface MethodsIterface
    {
       
        public IEnumerable<Thiss> ThissList1();
        public IEnumerable<Category> CategoryList1();
        public IEnumerable<Kingdoms> KingdomsList1();
        public IEnumerable<ClassA> ClassAList();

            //return db.Thiss.ToList();

    }
}
