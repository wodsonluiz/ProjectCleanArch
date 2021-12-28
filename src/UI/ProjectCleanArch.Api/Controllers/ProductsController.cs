using Microsoft.AspNetCore.Mvc;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _service.GetProductsAsync();

            return products;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddAsync(productDTO);

                return Ok(result);
            }

            return BadRequest("Product not include");
        }

        [HttpDelete]
        [Route("/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Alter([FromBody]ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.UpdateAsync(productDTO);

                return Ok(result);
            }

            return BadRequest("Product not update");
        }
    }
}
