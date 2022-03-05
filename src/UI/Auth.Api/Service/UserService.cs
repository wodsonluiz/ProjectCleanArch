using Auth.Api.Models;
using Auth.Api.Models.Dto;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Auth.Api.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<RegisterDto> _collection;
        public UserService(IUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<RegisterDto>(settings.UserCollectionName);
        }

        public async Task<RegisterDto> Autenticate(string email, string password)
        {
            var result = await GetRegister(email, password);

            return result;
        }
            
        public async Task<RegisterDto> Create(RegisterDto register)
        {
            await _collection.InsertOneAsync(register);

            return register;
        }

        private async Task<RegisterDto> GetRegister(string email, string password)
        {
            var filter = Builders<RegisterDto>.Filter.Eq(x => x.Email, email)
                       & Builders<RegisterDto>.Filter.Eq(x => x.Password, password);

            var register = await _collection.FindAsync(filter);

            return await register.FirstOrDefaultAsync();
        }

        public async Task Remove(string id) => await _collection.DeleteOneAsync(user => user.Id == id);
    }
}
