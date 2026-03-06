using InventoryHub.DTOs;
using InventoryHub.Services;
using InventoryHub.Responses;
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
            var products = _service.GetAll();

            return Ok(
                ResponseFactory.Success(products, "Products retrieved successfully")
            );
        }

        // GET: api/products/5
        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return NotFound(
                    ResponseFactory.Fail<ProductDTO>("Product not found")
                );
            }

            return Ok(
                ResponseFactory.Success(product, "Product retrieved successfully")
            );
        }

        // POST: api/products
        [HttpPost(Name = "SaveProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult SaveProduct([FromBody] ProductDTO productDTO)
        {
            var product = _service.Save(productDTO);

            if (product == null)
            {
                return Conflict(
                    ResponseFactory.Fail<ProductDTO>("Product already exists")
                );
            }

            return CreatedAtRoute(
                "GetProductById",
                new { id = product.Id },
                ResponseFactory.Success(product, "Product created successfully")
            );
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var updated = _service.Update(id, productDTO);

            if (updated == null)
            {
                return NotFound(
                    ResponseFactory.Fail<ProductDTO>("Product not found")
                );
            }

            return Ok(
                ResponseFactory.Success(updated, "Product updated successfully")
            );
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _service.DeleteById(id);

            if (deleted == null)
            {
                return NotFound(
                    ResponseFactory.Fail<ProductDTO>("Product not found")
                );
            }

            return Ok(
                ResponseFactory.Success(deleted, "Product deleted successfully")
            );
        }
    }
}