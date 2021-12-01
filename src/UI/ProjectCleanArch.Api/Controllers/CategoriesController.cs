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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly ILogger _logger;

        public CategoriesController(ICategoryService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            _logger.Information("Method {method}, {request}", HttpContext.Request.Method, HttpContext.Request.Path);

            var categories = await _service.GetCategoriesAsync();

            return categories;
        }
    }
}
