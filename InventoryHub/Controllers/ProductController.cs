using InventoryHub.DTOs;
using InventoryHub.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

namespace InventoryHub.Controllers
{
    //[Authorize] //for a jwtBearer
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/products")]

    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        //-----Enpoints

        [HttpGet(Name = "GetAllProducts")]
        public IActionResult GetProducts()
        {
            List<ProductDTO> productsDTO = _service.GetAll();
            return Ok(productsDTO);

        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
                return Ok(product);
        }

        [HttpPost(Name = "SaveProduct")]
        public IActionResult SaveProduct(ProductDTO productDTO)
        {
            var product = _service.Save(productDTO);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
    }
}