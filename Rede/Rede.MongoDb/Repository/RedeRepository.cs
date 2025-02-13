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

    public Task Remove(Domain.Entity.Rede entity)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entity.Rede> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.Entity.Rede>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public Task Editar(Domain.Entity.Rede entity)
    {
        throw new NotImplementedException();
    }
}