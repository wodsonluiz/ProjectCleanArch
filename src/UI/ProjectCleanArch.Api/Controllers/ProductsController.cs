using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger _logger;
        public ProductsController(IProductService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            _logger.Information("Method {method}, {request}", HttpContext.Request.Method, HttpContext.Request.Path);

            var products = await _service.GetProductsAsync();

            return products;
        }
    }
}
