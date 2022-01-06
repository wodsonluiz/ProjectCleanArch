using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectCleanArch.Api.Model
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [JsonProperty("confirm_password")]
        public string ConfirmPassword { get; set; }
    }
}
