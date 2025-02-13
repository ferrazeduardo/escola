using Moq;
using Rede.Application.UseCases.RedeUseCase.Inserir;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Inserir;

public class InserirTestFixture
{
    private List<DiaVencimento> ObterDiasVencimento()
    {
        var dia1 = new DiaVencimento() { Dia = 10 };
        var dia2 = new DiaVencimento() { Dia = 20 };
        var diasVencimento = new List<DiaVencimento>();
        diasVencimento.Add(dia1); 
        diasVencimento.Add(dia2);

        return diasVencimento;
    }
    
    public Rede.Domain.Entity.Rede ObterRede() =>
        new Rede.Domain.Entity.Rede(razaoSocial:  "teste razao social",nrCnpj:"84949144000189",codigoUsuario:1,diasVencimento: ObterDiasVencimento());

    public InserirRedeCommand ObterInserirRedeCommand()
    {
        var inserir = new InserirRedeCommand();
        inserir.razaoSocial = "teste razao social";
        inserir.cnpj = "84949144000189";
        inserir.codigoUsuario = 1;
        inserir.diasVencimentoRede = new();
        inserir.diasVencimentoRede.Add(10);
        inserir.diasVencimentoRede.Add(20);
        return inserir;
    }
    
    public Mock<IRedeRepository> redeRepositoryMock () => new Mock<IRedeRepository>();
}

[CollectionDefinition(nameof(InserirTestFixture))]
public class InserirTestFixtureCollection : ICollectionFixture<InserirTestFixture>
{
    
}