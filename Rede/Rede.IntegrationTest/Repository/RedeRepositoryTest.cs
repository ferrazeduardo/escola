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
    [Trait("MongoDb", "Repository - RedeRepository")]
    public async Task InserirRede()
    {
        // Arrange
        var rede = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede1" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "12344345455454",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}}};

        // Act
        await _repository.Inserir(rede);
        var Rede = await _repository.ObterPorId(rede.Id);

        // Assert
        Assert.NotNull(Rede);
        Assert.Equal(rede.RZ_SOCIAL, Rede.RZ_SOCIAL);
        Assert.Equal(rede.US_REGISTRO, Rede.US_REGISTRO);
        Assert.Equal(rede.DH_REGISTRO.Date, Rede.DH_REGISTRO.Date);
        Assert.Equal(rede.ST_REDE, Rede.ST_REDE);
        Assert.Equal(rede.NR_CNPJ, Rede.NR_CNPJ);
        Assert.Equal(rede.DiaVencimentos.Count, Rede.DiaVencimentos.Count);
        Assert.Equal(rede.DiaVencimentos[0].Dia, Rede.DiaVencimentos[0].Dia);
    }
    
    [Fact(DisplayName = nameof(RemoverRede))]
    [Trait("MongoDb", "Repository - RedeRepository")]
    public async Task RemoverRede()
    {
        var rede = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede1" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "12344345455454",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}}};
        
        await _repository.Inserir(rede);
        
        await _repository.Remove(rede);

        var Rede = await _repository.ObterPorId(rede.Id);
        
        Assert.Null(Rede);
    }

    [Fact(DisplayName = nameof(ObterTodos))]
    [Trait("MongoDb", "Repository - RedeRepository")]
    public async Task ObterTodos()
    {
        var rede1 = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede1" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "12344345455454",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}}};
        var rede2 = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede2" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "98765432112345",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}}};
        
        await _repository.Inserir(rede1);
        await _repository.Inserir(rede2);

        var redes = await _repository.ObterTodos();
        
        Assert.NotNull(redes.FirstOrDefault(r => r.Id == rede1.Id));
        Assert.NotNull(redes.FirstOrDefault(r => r.Id == rede2.Id));
    }

    [Fact(DisplayName = nameof(AddUnidade))]
    [Trait("MongoDb", "Repository - RedeRepository")]
    public async Task AddUnidade()
    {
        var rede = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede1" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "12344345455454",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}},Unidades = new List<Unidade>()};
        var unidade = new Unidade(){DS_ENDERECO = "Unidade1",DS_COMPLMENTO = "Complemente1",NR_CEP = "66000000",DH_REGISTRO = DateTime.Now,ST_UNIDADE = "S",NR_UNIDADE = "259",US_REGISTRO = 1};
        var telefones = new List<Telefone>();
        telefones.Add(new Telefone(){NR_TELEFONE = "91986451928"});
        unidade.Telefones = telefones;
        
        await _repository.Inserir(rede);
        await _repository.AddUnidade(rede.Id, unidade);
        
        var Rede = await _repository.ObterPorId(rede.Id);
        
        Assert.Contains(Rede.Unidades, x => x.Id == unidade.Id);
    }

    [Fact(DisplayName = nameof(AddDiaVencimento))]
    [Trait("MongoDb", "Repository - RedeRepository")]
    public async Task AddDiaVencimento()
    {
        var rede = new Rede.Domain.Entity.Rede {  RZ_SOCIAL = "Rede1" ,US_REGISTRO = 1,DH_REGISTRO = DateTime.Now, ST_REDE = "S",NR_CNPJ = "12344345455454",DiaVencimentos = new List<DiaVencimento>(){new DiaVencimento(){Dia = 10}},Unidades = new List<Unidade>()};
        var diaVencimento = new DiaVencimento() { Dia = 10 };

        await _repository.Inserir(rede);
        await _repository.AddDiaVencimento(rede.Id, diaVencimento);
        var Rede = await _repository.ObterPorId(rede.Id);
        
        Assert.Contains(rede.DiaVencimentos,d => d.Dia == diaVencimento.Dia);
    }
}


