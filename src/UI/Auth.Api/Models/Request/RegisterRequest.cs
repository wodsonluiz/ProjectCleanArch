using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Auth.Api.Models.Request
{
    public class RegisterRequest
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("confirm_password")]
        public string ConfirmPassword { get; set; }
    }
}
