using MongoDB.Driver;
using ProjectMongoDB.Models;

namespace ProjectMongoDB.Services
{
    public class BahanService
    {
        private readonly IMongoCollection<Bahan> _col;

        public BahanService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("bakerydb");
            _col = db.GetCollection<Bahan>("bahan");
        }

        public async Task<List<Bahan>> GetAsync() =>
            await _col.Find(_ => true).ToListAsync();

        public async Task<Bahan?> GetByIdAsync(string id) =>
            await _col.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Bahan entity) =>
            await _col.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, Bahan entity) =>
            await _col.ReplaceOneAsync(x => x.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _col.DeleteOneAsync(x => x.Id == id);
    }
}


