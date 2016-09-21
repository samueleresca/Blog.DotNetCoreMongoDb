using MongoDB.Bson;

public class PostModel
{

    public ObjectId _id { get; set; }
    public string title { get; set; }
    public string content { get; set; }
    public string name { get; set; }

}