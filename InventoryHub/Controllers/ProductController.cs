using InventoryHub.DTOs;
using InventoryHub.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace InventoryHub.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/products
        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetProducts()
        {
            List<ProductDTO> productsDTO = _service.GetAll();
            return Ok(productsDTO);
        }

        // GET: api/products/5
        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/products
        [HttpPost(Name = "SaveProduct")]
        public IActionResult SaveProduct([FromBody] ProductDTO productDTO)
        {
            var product = _service.Save(productDTO);

            if (product == null)
            {
                return Conflict("Product already exists");
            }

            return CreatedAtRoute(
                "GetProductById",
                new { id = product.Id },
                product
            );
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var updated = _service.Update(id, productDTO);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _service.DeleteById(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
    }
}