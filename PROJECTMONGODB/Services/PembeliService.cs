using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectMongoDB.Models;
using ProjectMongoDB.Settings;

namespace ProjectMongoDB.Services
{
    public class PembeliService
    {
        private readonly IMongoCollection<Pembeli> _pembeliCollection;

        public PembeliService(IOptions<MongoDBSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _pembeliCollection = database.GetCollection<Pembeli>("Pembeli"); // tetep pake "Pembeli"
        }

        public async Task<List<Pembeli>> GetAsync() =>
            await _pembeliCollection.Find(_ => true).ToListAsync();

        public async Task<Pembeli?> GetByIdAsync(string id) =>
            await _pembeliCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Pembeli pembeli) =>
            await _pembeliCollection.InsertOneAsync(pembeli);

        public async Task UpdateAsync(string id, Pembeli pembeli) =>
            await _pembeliCollection.ReplaceOneAsync(x => x.Id == id, pembeli);

        public async Task DeleteAsync(string id) =>
            await _pembeliCollection.DeleteOneAsync(x => x.Id == id);
    }
}