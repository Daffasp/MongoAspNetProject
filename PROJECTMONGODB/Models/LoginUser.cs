using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectMongoDB.Models
{
    public class LoginUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string username { get; set; } = string.Empty;

        [BsonElement("password")]
        public string password { get; set; } = string.Empty;
    }
}
