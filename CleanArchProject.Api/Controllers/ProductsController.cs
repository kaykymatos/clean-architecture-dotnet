using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var result = await _productService.GetProducts();
            if (result == null)
                return NotFound("Products not found");
            return Ok(result);
        }
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var result = await _productService.GetById(id);
            if (result == null)
                return NotFound("Product not found!");
            return Ok(await _productService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest("Invalid Data!");
            await _productService.Add(product);
            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO product)
        {
            var a = new KeyValuePair<string, string>("Nome", "O nome não pode ser nulo!");
            if (id != product.Id)
                return BadRequest("Product Id  is invalid!");
            if (product == null)
                return BadRequest("Invalid Data!");

            var result = await _productService.GetById(id);
            if (result == null)
                return NotFound("Product not found");

            if (product == null)
                return BadRequest("Invalid Data!");
            await _productService.Update(product);
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var result = await _productService.GetById(id);
            if (result == null)
                return NotFound("Product not found");
            await _productService.Remove(id);
            return Ok(result);
        }
    }
}
