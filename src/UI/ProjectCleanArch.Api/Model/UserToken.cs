using System;

namespace ProjectCleanArch.Api.Model
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Experition { get; set; }
    }
}
