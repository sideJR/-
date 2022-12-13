using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CM8_開心農場.Models
{
    public class Fruit
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Weigh { get; set; }
    }
}