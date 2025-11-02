using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectMongoDB.Models;
using ProjectMongoDB.Settings;

namespace ProjectMongoDB.Services
{
    public class LoginService
    {
        private readonly IMongoCollection<LoginUser> _userCollection;

        public LoginService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var database = client.GetDatabase("wpu"); // ← database kamu
            _userCollection = database.GetCollection<LoginUser>("user"); // ← nama koleksi kamu
        }

        public async Task<LoginUser?> ValidateUserAsync(string username, string password)
        {
            // Sesuaikan dengan nama field di MongoDB (huruf kecil semua)
            return await _userCollection
                .Find(u => u.username == username && u.password == password)
                .FirstOrDefaultAsync();
        }
    }
}
