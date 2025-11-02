using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectMongoDB.Models
{
    public class Bahan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("nama_bahan")]
        public string NamaBahan { get; set; } = string.Empty;

        [BsonElement("satuan")]
        public string Satuan { get; set; } = string.Empty; // contoh: kg, gram, liter, pack

        [BsonElement("stok")]
        public int Stok { get; set; }

        [BsonElement("min_stok")]
        public int MinimumStok { get; set; } // batas minimal untuk reminder
    }
}


