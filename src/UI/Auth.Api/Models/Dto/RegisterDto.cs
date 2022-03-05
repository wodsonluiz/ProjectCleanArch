using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Auth.Api.Models.Dto
{
    public class RegisterDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
