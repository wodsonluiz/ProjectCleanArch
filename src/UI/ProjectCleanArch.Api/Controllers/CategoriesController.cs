using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            var categories = await _service.GetCategoriesAsync();

            return categories;
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
    }
}
