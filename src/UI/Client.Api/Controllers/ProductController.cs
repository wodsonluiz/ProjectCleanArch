using Client.Api.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Client.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _service.GetProducts();

            return Ok(result);
        }
    }
}
