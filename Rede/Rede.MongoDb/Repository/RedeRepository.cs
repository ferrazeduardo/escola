using MongoDB.Driver;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;
using Rede.MongoDb.Model;

namespace Rede.MongoDb.Repository;

public class RedeRepository : IRedeRepository
{
    private readonly MongoDBContext _mongoDbContext;

    public RedeRepository(MongoDBContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }
    
    public async Task Inserir(Domain.Entity.Rede entity)
    {
         await _mongoDbContext.RedeContext.InsertOneAsync(entity);
    }

    public async Task Remove(Domain.Entity.Rede entity)
    {
        var filter = Builders<Domain.Entity.Rede>.Filter.Eq(r => r.Id, entity.Id);
        await _mongoDbContext.RedeContext.DeleteOneAsync(filter);
    }

    public async Task<Domain.Entity.Rede> ObterPorId(Guid id)
    {
        var filter = Builders<Domain.Entity.Rede>.Filter.Eq(r => r.Id, id);
        return await _mongoDbContext.RedeContext.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<Domain.Entity.Rede>> ObterTodos()
    {
        var filter = Builders<Domain.Entity.Rede>.Filter.Empty;
        return await _mongoDbContext.RedeContext.Find(filter).ToListAsync();
    }

    public Task Editar(Domain.Entity.Rede entity)
    {
        throw new NotImplementedException();
    }
    
    public async Task AddUnidade(Guid id, Unidade unidade)
    {
        var filter = Builders<Domain.Entity.Rede>.Filter.Eq(r => r.Id, id);
        var update = Builders<Domain.Entity.Rede>.Update.Push("Unidades", unidade);
        await _mongoDbContext.RedeContext.UpdateOneAsync(filter, update);
    }

}

