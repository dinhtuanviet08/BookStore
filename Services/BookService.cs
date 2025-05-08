using BookStoreApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
namespace BookStoreApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public BookService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new
            MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase =
            mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _booksCollection = mongoDatabase.GetCollection<Book>
            (mongoDbSettings.Value.BooksCollectionName);
        }
        public async Task<List<Book>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();
        public async Task<Book> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id ==
        id).FirstOrDefaultAsync();
        public async Task CreateAsync(Book newBook) =>
        await _booksCollection.InsertOneAsync(newBook);
        public async Task UpdateAsync(string id, Book updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id,
        updatedBook);
        public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}