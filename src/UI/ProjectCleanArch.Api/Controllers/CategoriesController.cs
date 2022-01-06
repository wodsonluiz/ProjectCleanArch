using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _service.GetCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetId(int id)
        {
            var category = await _service.GetByIdAsync(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(categoryDTO);

                return Ok(result);
            }

            return BadRequest("Category not include");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.GetByIdAsync(id);

            if (category == null) return BadRequest("Category not found");

            await _service.RemoveAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(categoryDTO);
                return Ok(result);
            }
            
            return BadRequest("Category not update");
        }
    }
}
