using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CM8_開心農場.Models;

namespace CM8_開心農場.Controllers
{
    public class ProductController : ApiController
    {
        Fruit[] MyFruit = new Fruit[]
        {
            new Fruit{Id = 1, Name = "香蕉", Price = 30, Weigh = 3.6},
            new Fruit{Id = 2, Name = "鳳梨", Price = 50, Weigh = 5.2}
        };
        public IEnumerable<Fruit> GetAll()
        {
            return MyFruit;
        }
        public IHttpActionResult Get(int id)
        {
            var x = MyFruit.FirstOrDefault((p) => p.Id == id);

            if(x == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(x);
            }            
        }
    }
}
