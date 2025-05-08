using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }
        [BsonElement("Author")]
        public string Author { get; set; }
        [BsonElement("Price")]
        public decimal Price { get; set; }
        [BsonElement("PublishedDate")]
        public DateTime PublishedDate { get; set; }
    }
}