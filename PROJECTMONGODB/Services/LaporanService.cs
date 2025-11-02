using MongoDB.Driver;
using ProjectMongoDB.Models;

namespace ProjectMongoDB.Services
{
    public class LaporanService
    {
        private readonly IMongoCollection<LaporanPenjualan> _col;

        public LaporanService(IConfiguration cfg)
        {
            // Boleh ganti key ini kalau kamu sudah punya MongoDBSettings sendiri
            var conn = cfg["Mongo:ConnectionString"] ?? "mongodb://localhost:27017";
            var dbName = cfg["Mongo:DatabaseLaporan"] ?? "db_laporan";

            var client = new MongoClient(conn);
            var db = client.GetDatabase(dbName);
            _col = db.GetCollection<LaporanPenjualan>("laporanPenjualan");
        }

        public async Task<List<LaporanPenjualan>> GetAsync() =>
            await _col.Find(Builders<LaporanPenjualan>.Filter.Empty)
                      .SortByDescending(x => x.Tanggal)
                      .ToListAsync();

        public async Task<LaporanPenjualan?> GetByIdAsync(string id) =>
            await _col.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(LaporanPenjualan entity) =>
            await _col.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, LaporanPenjualan entity) =>
            await _col.ReplaceOneAsync(x => x.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _col.DeleteOneAsync(x => x.Id == id);
    }
}
