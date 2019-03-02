using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_1.Models.Interfaces;

namespace WebApi_1.Models
{
    public class ProductRepository : IDisposable, IProductRepository
    {
        private ProductContext db { get; set; }
        
        public ProductRepository(ProductContext _db)
        {
            db = _db;
        }
        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetById(Guid _id)
        {
            return db.Products.FirstOrDefault<Product>(p => p.Id.Equals(_id));
        }

        public Product Add(ProductCreateInputModel p)
        {
            Product product = new Product { Id = Guid.NewGuid(), Name = p.Name, Price = p.Price };

            db.Entry(product).State = EntityState.Modified;
            db.Products.Add(product);
            var result = db.SaveChanges();
            if (result == 1)
                return product;
            else
                return null;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Update(ProductUpdateInputModel product)
        {
            var p = db.Products.SingleOrDefault(m => m.Id == product.Id);
            p.Name = product.Name;
            p.Price = product.Price;
            db.Entry(p).State = EntityState.Modified;
            db.Update(p);
            if (db.SaveChanges() == 1)
                return true;
            else
                return false;
        }

        public bool Delete(Guid id)
        {
            Product p = db.Products.SingleOrDefault(m => m.Id == id);
            if (p == null)
                return false;
            else
            {
                db.Products.Remove(p);
                db.SaveChangesAsync();
                return true;
            }
        }
    }
}
