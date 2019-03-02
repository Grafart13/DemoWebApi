using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi_1.Models;

namespace WebApi_1.Validators
{
    public class MyGuidValidator : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            Product p = (Product)value;
            bool result = true;
            if (p.Id == Guid.Empty)
                result = false;
            return result;
        }
    }
}
