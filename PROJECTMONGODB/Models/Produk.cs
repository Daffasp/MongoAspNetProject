using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectMongoDB.Models
{
    public class Produk
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;  // ✅ hilang warning

        [BsonElement("nama_produk")]
        public string NamaProduk { get; set; } = string.Empty;

        [BsonElement("harga")]
        public int Harga { get; set; }

        [BsonElement("kategori")]
        public string Kategori { get; set; } = string.Empty;

        [BsonElement("stok")]
        public int Stok { get; set; }
    }
}
