using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null)
            {
                return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null) return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO category)
        {
            if (category == null) return BadRequest("Invalid data");

            await _categoryService.Add(category);

            return CreatedAtAction("Get", new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.Id) return BadRequest();
            if (category == null) return BadRequest();

            await _categoryService.Update(category);

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete (int id)
        {
            var category = await _categoryService.GetById(id);
            
            if (category == null) return NotFound("Category not found");
            await _categoryService.Remove(id);

            return Ok(category);
        }
    }
}
