using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectCleanArch.Api.Model
{
    public class LoginResquest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
