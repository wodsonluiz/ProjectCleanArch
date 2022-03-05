using Client.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Api.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
