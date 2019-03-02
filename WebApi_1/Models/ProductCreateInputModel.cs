using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi_1.Validators;

namespace WebApi_1.Models
{
    public class ProductCreateInputModel
    {
        [Required(ErrorMessage = "Name of product is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Decimal price of product is required")]
        [RegularExpression(@"^\$?\d+([\.\,](\d{1,2}))?$", ErrorMessage = "Unaccaptable format of price. After '.|,' should be max two digits.")]
        public decimal? Price { get; set; }
    }
}
