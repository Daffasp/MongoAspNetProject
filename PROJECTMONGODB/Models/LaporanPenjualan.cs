using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectMongoDB.Models
{
    public class LaporanPenjualan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        // Sesuaikan dengan nama field di koleksi MongoDB kamu
        [BsonElement("Tanggal")]
        public DateTime Tanggal { get; set; }

        [BsonElement("NamaProduk")]
        public string NamaProduk { get; set; } = string.Empty;

        [BsonElement("JumlahTerjual")]
        public int JumlahTerjual { get; set; }

        [BsonElement("HargaSatuan")]
        public int HargaSatuan { get; set; }

        [BsonIgnore]
        public int Total => JumlahTerjual * HargaSatuan;
    }
}
