using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models
{
    public class Product
    {
        public Guid? Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }

 //       public Product(ProductCreateInputModel p)
//        {
//            this.Id = 0;
//            this.Name = p.Name;
//            this.Price = p.Price;
 //       }
    }
}
