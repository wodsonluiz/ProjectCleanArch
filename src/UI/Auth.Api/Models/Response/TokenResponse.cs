using System;

namespace Auth.Api.Models.Response
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Experition { get; set; }
    }
}
