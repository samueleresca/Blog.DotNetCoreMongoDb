using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blog.DotNetCoreMongoDb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;


        public ValuesController()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("demoDb");

        }

        // GET api/values
        [HttpGet]
        public  List<PostModel> Get(PostModel filter)
        {
            var collection= _database.GetCollection<PostModel>("posts");
           return  collection.Find<PostModel>(filter).ToList();
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
