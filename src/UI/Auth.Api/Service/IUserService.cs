using Auth.Api.Models.Dto;
using System.Threading.Tasks;

namespace Auth.Api.Service
{
    public interface IUserService
    {
        Task<RegisterDto> Autenticate(string email, string password);
        Task<RegisterDto> Create(RegisterDto register);
        Task Remove(string id);
    }
}
