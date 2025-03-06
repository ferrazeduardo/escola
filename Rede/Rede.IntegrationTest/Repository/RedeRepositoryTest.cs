using Microsoft.Extensions.Configuration;
using Mongo2Go;
using MongoDB.Driver;
using Rede.Domain.Entity;
using Rede.MongoDb.Model;
using Rede.MongoDb.Repository;

namespace Rede.IntegrationTest.Repository;

public class RedeRepositoryTest : IAsyncLifetime
{
    private MongoDbRunner _runner;
    private MongoDBContext _context;
    private RedeRepository  _repository;
    
    public async Task InitializeAsync()
    {
        _runner = MongoDbRunner.Start(); // Inicia MongoDB em memória
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "MongoDB:ConnectionString", "mongodb://admin:admlocal123-@localhost:27017" },
                { "MongoDB:DatabaseName", "escola" }
            }).Build()!;
            
        _context = new MongoDBContext(configuration);
        _repository = new RedeRepository(_context);

        await Task.CompletedTask;

    }

    public Task DisposeAsync()
    {
        _runner.Dispose();
        return Task.CompletedTask;
    }
    
    [Fact(DisplayName = nameof(InserirRede))]
    public async Task InserirRede()
    {
        // Arrange
        var rede = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede1" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "12344345455454",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}}};

        // Act
        await _repository.Inserir(rede);
        var retrievedRede = await _repository.ObterPorId(rede.Id);

        // Assert
        Assert.NotNull(retrievedRede);
        Assert.Equal(rede.RZ_SOCIAL, retrievedRede.RZ_SOCIAL);
        Assert.Equal(rede.US_REGISTRO, retrievedRede.US_REGISTRO);
        Assert.Equal(rede.DH_REGISTRO.Date, retrievedRede.DH_REGISTRO.Date);
        Assert.Equal(rede.ST_REDE, retrievedRede.ST_REDE);
        Assert.Equal(rede.NR_CNPJ, retrievedRede.NR_CNPJ);
        Assert.Equal(rede.DiaVencimentos.Count, retrievedRede.DiaVencimentos.Count);
        Assert.Equal(rede.DiaVencimentos[0].Dia, retrievedRede.DiaVencimentos[0].Dia);
    }
}


