using MongoDB.Driver;
using ProjectMongoDB.Models;

namespace ProjectMongoDB.Services
{
    public class ProdukService
    {
        private readonly IMongoCollection<Produk> _produkCollection;

        public ProdukService()
        {
            // ✅ Koneksi ke MongoDB lokal
            var client = new MongoClient("mongodb://localhost:27017");

            // ✅ Nama database (pastikan sama dengan yang kamu pakai di MongoDB Compass)
            var database = client.GetDatabase("bakerydb");

            // ✅ Nama koleksi (collection) yang berisi data produk
            _produkCollection = database.GetCollection<Produk>("produk");
        }

        // ✅ Ambil semua data produk
        public async Task<List<Produk>> GetAsync() =>
            await _produkCollection.Find(_ => true).ToListAsync();

        // ✅ Ambil produk berdasarkan ID
        public async Task<Produk?> GetByIdAsync(string id) =>
            await _produkCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // ✅ Tambah produk baru
        public async Task CreateAsync(Produk produk) =>
            await _produkCollection.InsertOneAsync(produk);

        // ✅ Update produk
        public async Task UpdateAsync(string id, Produk produk) =>
            await _produkCollection.ReplaceOneAsync(x => x.Id == id, produk);

        // ✅ Hapus produk
        public async Task DeleteAsync(string id) =>
            await _produkCollection.DeleteOneAsync(x => x.Id == id);
    }
}
