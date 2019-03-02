using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models
{
    public class ProductUpdateInputModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\$?\d+([\.\,](\d{1,2}))?$", ErrorMessage = "Unaccaptable format of price. After '.|,' should be max two digits.")]
        public decimal Price { get; set; }
    }
}
