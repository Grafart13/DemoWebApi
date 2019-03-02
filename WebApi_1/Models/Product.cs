using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name of product is required")]
        [MaxLength(100, ErrorMessage = "Name of product cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Decimal price of product is required")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }
    }
}
