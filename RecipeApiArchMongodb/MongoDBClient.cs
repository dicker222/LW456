
using MongoDB.Driver;

namespace RecipeApi;

public class MongoDBClient
{
    // Додали "null!" - це хак, який каже компілятору: "Забий, я гарантую, що тут будуть дані".
    private IMongoDatabase _db = null!; 
    
    // Додали "?" - це означає: "Ця змінна МОЖЕ бути null на початку".
    private static MongoDBClient? _instance;

    public static MongoDBClient Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MongoDBClient();
            }
            return _instance;
        }
    }

    private MongoDBClient()
    {
        // Встав сюди свій рядок з працюючим паролем superuser
        var connectionString = "mongodb+srv://bahniimike_db_user:v2qejGWyCTSfGmaH@cluster0.maa37fs.mongodb.net/?appName=Cluster0";

        
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase("RecipeDb");
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _db.GetCollection<T>(name);
    }
}