using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Fullstack.Shared
{
    public class User{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public string Password { get; set; }
    }
}
