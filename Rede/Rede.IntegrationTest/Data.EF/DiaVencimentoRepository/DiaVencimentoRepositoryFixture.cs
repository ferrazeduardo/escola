using Microsoft.EntityFrameworkCore;
using Rede.Data.EF;
using Rede.Domain.Entity;

namespace Rede.IntegrationTest.Data.EF.DiaVencimentoRepository;

[CollectionDefinition(nameof(DiaVencimentoRepositoryFixture))]
public class DiaVencimentoRepositoryCollection
    : ICollectionFixture<DiaVencimentoRepositoryFixture>
{
    
}

public class DiaVencimentoRepositoryFixture
{

    public DiaVencimento GetDiaVencimento()
    {
        return new DiaVencimento(10, Guid.NewGuid());
    }
    
      
    public RedeDbContext CreateDbContext()
    {
        return new RedeDbContext(
            new DbContextOptionsBuilder<RedeDbContext>()
                .UseInMemoryDatabase("integration-tests-db-rede")
                .Options
        );
    }
}