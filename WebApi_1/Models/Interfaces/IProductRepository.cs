using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid _id);
        Product Add(ProductCreateInputModel product);
        bool Update(ProductUpdateInputModel product);
        bool Delete(Guid id);
    }
}
