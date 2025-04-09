using Moq;
using Rede.Application.UseCases.RedeUseCase.Save;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Test.UnitTest.Application.UseCase.RedeUseCase.Inserir;

public class SaveTestFixture
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

    
    public SaveRedeInput ObterInserirRedeCommand()
    {
        var save = new SaveRedeInput();
        save.razaoSocial = "teste razao social";
        save.cnpj = "84949144000189";
        save.codigoUsuario = 1;
        save.diasVencimentoRede = new();
        save.diasVencimentoRede.Add(10);
        save.diasVencimentoRede.Add(20);
        return save;
    }
    
    public Mock<IRedeRepository> redeRepositoryMock () => new Mock<IRedeRepository>();
    
    public Mock<IUnitOfWork> unitOfWorkMock () => new Mock<IUnitOfWork>();
}

[CollectionDefinition(nameof(SaveTestFixture))]
public class InserirTestFixtureCollection : ICollectionFixture<SaveTestFixture>
{
    
}