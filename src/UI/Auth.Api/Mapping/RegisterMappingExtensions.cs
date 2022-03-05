using Auth.Api.Models.Dto;
using Auth.Api.Models.Request;

namespace Auth.Api
{
    public static class RegisterMappingExtensions
    {
        public static RegisterDto MappingToDto(this RegisterRequest request)
        {
            return new RegisterDto()
            {
                Id = request.Id,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword
            };
        }
    }
}
