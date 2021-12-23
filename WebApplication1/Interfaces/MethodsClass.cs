using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public class MethodsClass : MethodsIterface
    {
        private RedBookContext db;
       

        public MethodsClass(RedBookContext context)
        {
            var Client = new HttpClient();
            
            this.db = context;  
        }
       
        public IEnumerable<Thiss> ThissList1()
        
        {
            return db.Thiss.AsEnumerable();
        }
        public IEnumerable<Category> CategoryList1()
        {
            return db.Category.ToArray();
        }
        public IEnumerable<Kingdoms> KingdomsList1()
        {
            return db.Kingdoms.ToArray();
        }
        public IEnumerable<ClassA> ClassAList()
        {
            return db.ClassA.ToArray();
        }
    }
}
