using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Rede.MongoDb.Model;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
        var databaseName = configuration.GetSection("MongoDB:DatabaseName").Value;

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    
    public IMongoCollection<Domain.Entity.Rede> RedeContext => _database.GetCollection<Domain.Entity.Rede>("rede");
}