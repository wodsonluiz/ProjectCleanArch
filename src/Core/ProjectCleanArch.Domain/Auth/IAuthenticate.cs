using System.Threading.Tasks;

namespace ProjectCleanArch.Domain.Auth
{
    public interface IAuthenticate
    {
        Task<bool> Autenticate(string email, string password);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
