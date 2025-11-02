using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProjectMongoDB.Models
{
    public class Pembeli
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nama")]
        [Required(ErrorMessage = "Nama harus diisi")]
        public string Nama { get; set; } = string.Empty;

        [BsonElement("email")]
        [Required(ErrorMessage = "Email harus diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("jurusan")]
        [Required(ErrorMessage = "Kategori harus diisi")]
        public string Jurusan { get; set; } = string.Empty;

        [BsonElement("alamat")]
        [Required(ErrorMessage = "Alamat harus diisi")]
        public string Alamat { get; set; } = string.Empty;
    }
}