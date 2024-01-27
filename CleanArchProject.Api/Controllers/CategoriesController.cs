using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetProducts()
        {
            var result = await _categoryService.GetCategories();
            if (result == null)
                return NotFound("Categories not found");
            return Ok(result);
        }
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetProduct(int id)
        {
            var result = await _categoryService.GetById(id);
            if (result == null)
                return NotFound("Category not found!");
            return Ok(await _categoryService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CategoryDTO category)
        {
            if (category == null)
                return BadRequest("Invalid Data!");
            await _categoryService.Add(category);
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.Id)
                return BadRequest("Category Id  is invalid!");
            if (category == null)
                return BadRequest("Invalid Data!");

            var result = await _categoryService.GetById(id);
            if (result == null)
                return NotFound("Category not found");

            if (category == null)
                return BadRequest("Invalid Data!");
            await _categoryService.Update(category);
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var result = await _categoryService.GetById(id);
            if (result == null)
                return NotFound("Category not found");
            await _categoryService.Remove(id);
            return Ok(result);
        }
    }
}
