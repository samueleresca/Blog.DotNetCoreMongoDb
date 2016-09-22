using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Blog.DotNetCoreMongoDb.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<PostModel> _collection;

        public PostsController()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("demoDb");
            _collection = _database.GetCollection<PostModel>("posts");
        }

        // GET api/posts
        [HttpGet]
        public List<PostModel> Get(string jsonQuery = "{}")
        {
            var queryDoc = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            Console.WriteLine(queryDoc);
            return _collection.Find<PostModel>(queryDoc).ToList();
        }
    }
}
