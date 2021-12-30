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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _service.GetProductsAsync();

            if (products == null)
            {
                return NotFound("Not found products");
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Not found product");
            }

            return Ok(product);
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
        [Route("{id}")]
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
