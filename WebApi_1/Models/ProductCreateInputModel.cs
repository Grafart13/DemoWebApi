using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models
{
    public class ProductCreateInputModel
    {
        [MaxLength(100)]
        public string Name;
        public decimal Price;
    }
}
