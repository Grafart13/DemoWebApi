using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models
{
    public class ProductCreateInputModel
    {
        [Required]
        [MaxLength(100)]
        public string Name;

        [Required]
        [RegularExpression(@"^\$?\d+([\.\,](\d{1,2}))?$", ErrorMessage = "Unaccaptable format of price. After '.|,' should be max two digits.")]
        public decimal Price;
    }
}
