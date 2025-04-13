using Microsoft.EntityFrameworkCore;
using Rede.Data.EF;
using Rede.Domain.Entity;

namespace Rede.IntegrationTest.Data.EF.RedeRepository;

[CollectionDefinition(nameof(RedeRepositoryFixture))]
public class RedeRepositoryCollection
    : ICollectionFixture<RedeRepositoryFixture>
{
    
}

public class RedeRepositoryFixture
{


    public Domain.Entity.Rede GetRede()
    {
        var rede = new Domain.Entity.Rede("Minha Rede", "12345678901234", 1, new List<DiaVencimento>
        {
            new DiaVencimento(5, Guid.NewGuid()),
            new DiaVencimento(10, Guid.NewGuid())
        });

        // Criando Unidades associadas
        var unidade1 = new Unidade("Unidade 1", "66000000","98",1,
            "cOMPLEMENTO TESTE",rede);
        var unidade2 = new Unidade("Unidade 2" , "66000000","98",1,"cOMPLEMENTO TESTE",rede);

        rede.SetUnidades(new List<Unidade> { unidade1, unidade2 });

        // Adicionando Telefones às Unidades
        unidade1.Telefones.Add(new Telefone("999999999",unidade1.Id));
        unidade2.Telefones.Add(new Telefone("888888888",unidade2.Id));
        
        return rede;

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