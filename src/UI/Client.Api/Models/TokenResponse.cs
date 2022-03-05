using System;

namespace Client.Api.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Experition { get; set; }
    }
}
