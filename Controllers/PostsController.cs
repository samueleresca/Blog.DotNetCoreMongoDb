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


        public PostsController()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("demoDb");
        }

        // GET api/values
        [HttpGet]
        public List<PostModel> Get(string jsonQuery = "{}")
        {
            var collection = _database.GetCollection<PostModel>("posts");            
            var queryDoc = new QueryDocument(BsonSerializer.Deserialize<BsonDocument>(jsonQuery));
            Console.WriteLine(queryDoc);
            return collection.Find<PostModel>(queryDoc).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
