using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApi_1.Models;
using WebApi_1.Models.Interfaces;
using WebApi_1.Validators;

namespace WebApi_1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetAll();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product
        [HttpPut]
        public IActionResult PutProduct([FromBody] ProductUpdateInputModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ProductExists(product.Id))
            {
                return BadRequest("Product is not exist");
            }

            var result = _repository.Update(product);
      
            if (result == true)
                return Ok("Successfully done PUT Http method");
            else
            {
                if (!ProductExists(product.Id))
                    return NotFound();
                else
                    return BadRequest();
            }
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductCreateInputModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product p = _repository.Add(product);

            if (p != null)
                return CreatedAtAction("GetProduct", new { id = p.Id }, p);
            else
                return BadRequest();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _repository.Delete(id);
            if (result == false)
                return NotFound();
            else
                return Ok($"OK Removing product with {id} id");
        }

        private bool ProductExists(Guid id)
        {
            return _repository.GetAll().Any(e => e.Id == id);
        }
    }
}