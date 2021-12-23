using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ThissController : ControllerBase
    {
        private RedBookContext db;
        private MethodsClass _methods;
  

        public ThissController(RedBookContext context, MethodsClass methods)
        {
            this.db = context;
            _methods = methods;
           
        }


        [Route("[action]")]
        public IEnumerable<Thiss> ThissList()
        {
            return  _methods.ThissList1();
          
        }
        [Route("[action]")]
        public IEnumerable<Category> CategoryList()
        {
            return _methods.CategoryList1();
        }
        [Route("[action]")]
        public IEnumerable<ClassA> ClassList()
        {
            return _methods.ClassAList();
        }
        [Route("[action]")]
        public IEnumerable<Kingdoms> KingdomsList()
        {
            return _methods.KingdomsList1();
        }
        [Route("CategoryName")]
        public IEnumerable<string> CategoryNameList()
        {
            
            return db.Category.Select(x=>x.Name).ToArray();

        }

        //[Route("Kingdoms")]
        //public IEnumerable<Kingdoms> KingdomsList()
        //{
        //    return _methods.KingdomsList1();
        //}
        [Route("KingdomsName")]
        public IEnumerable<string> KingdomsNameList()
        {
            return db.Kingdoms.Select(x => x.Name).ToArray();
        }

        [Route("ClassA")]
        public IEnumerable<ClassA> ClassAList(string kingdom)
        {
            if(kingdom==null)
            {
                return db.ClassA.ToArray();
            }
            else
            {
                return db.ClassA.Where(x => x.Kingdom.Name == kingdom).ToArray();
            }
        }


        [HttpGet("name/{name}")]
        public ActionResult<Thiss> Name(string name)
        {

            var product = db.Thiss.FirstOrDefault(product => product.Name == name);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("{id}")]
        public ActionResult<Thiss> GetThissById(int id)
        {

            var product = db.Thiss.FirstOrDefault(product => product.ThisId == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpPut]
        [Route("add")]
        public ActionResult AddThiss(Thiss thiss)
        {
            db.Thiss.Add(thiss);

            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(400); // invalid request
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult RemoveThiss(int id)
        {
            var thiss = db.Thiss.Find(id);

            if (thiss == null)
            {
                return NotFound();
            }

            db.Thiss.Remove(thiss);

            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Route("{id}")]
        public ActionResult ModifyProduct(int id, Thiss thiss)
        {
            var oldProduct = db.Thiss.Find(id);

            if (oldProduct == null)
            {
                return NotFound();
            }

            oldProduct.Name = thiss.Name;
            oldProduct.Descc = thiss.Descc;
            oldProduct.CategoryId = thiss.CategoryId;

            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //[HttpGet("{name}")]
        //public ActionResult<Thiss> Name(string name)
        //{

        //    var product = db.Thiss.FirstOrDefault(product => product.Name == name);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}
    }
}
