using Microsoft.EntityFrameworkCore;
using Rede.Data.EF;
using Rede.Domain.Entity;

namespace Rede.IntegrationTest.Data.EF.RedeRepository;


[Collection(nameof(RedeRepositoryFixture))]
public class RedeRepositoryTest
{
    private readonly RedeRepositoryFixture _fixture;

    public RedeRepositoryTest(RedeRepositoryFixture fixture)
    {
        _fixture = fixture;
        
    }
    
    [Fact]
    public async Task DeveInserirRedeComUnidadesETelefonesEDiaVencimentos()
    {
        
        RedeDbContext _context = _fixture.CreateDbContext();
        var RedeRepository = new Rede.Data.EF.Repository.RedeRepository(_context);
        // Criando uma Rede
        var rede = _fixture.GetRede();

        // Executando o método de inserção
        await RedeRepository.Inserir(rede,CancellationToken.None);
        await _context.Set<Unidade>().AddRangeAsync(rede.Unidades);
        await _context.Set<Telefone>().AddRangeAsync(rede.Unidades.SelectMany(u => u.Telefones));
        await _context.Set<DiaVencimento>().AddRangeAsync(rede.DiaVencimentos);
        await _context.SaveChangesAsync();

        // Validando se os registros foram salvos corretamente
        Assert.Equal(1, await _context.Set<Domain.Entity.Rede>().CountAsync());
        Assert.Equal(2, await _context.Set<Unidade>().CountAsync());
        Assert.Equal(2, await _context.Set<Telefone>().CountAsync());
        Assert.Equal(2, await _context.Set<DiaVencimento>().CountAsync());
    }
    
    
    [Fact]
    public async Task DeveRemoverRedeComUnidadesEDiaVencimentos()
    {
        RedeDbContext _context = _fixture.CreateDbContext();
        var RedeRepository = new Rede.Data.EF.Repository.RedeRepository(_context);
        // Criando uma Rede
        var rede = _fixture.GetRede();
   
        
        await _context.Set<Domain.Entity.Rede>().AddAsync(rede);
        await _context.SaveChangesAsync();
        var redeDb = await _context.Set<Domain.Entity.Rede>().FirstOrDefaultAsync(r => r.Id == rede.Id);

        await RedeRepository.Remove(redeDb,CancellationToken.None);
        await _context.SaveChangesAsync();
        var redeDbRemove = await _context.Set<Domain.Entity.Rede>().FirstOrDefaultAsync(r => r.Id == rede.Id);

        
        Assert.NotNull(redeDb);
        Assert.Null(redeDbRemove);
        
    }

    [Fact]
    public async Task DeveObterUmaListaDeRedeComUnidadesEDiaVencimentos()
    {
        RedeDbContext _context = _fixture.CreateDbContext();
        var RedeRepository = new Rede.Data.EF.Repository.RedeRepository(_context);
        // Criando uma Rede
        var rede = _fixture.GetRede();
        var rede2 = _fixture.GetRede();
   
        
        await _context.Set<Domain.Entity.Rede>().AddAsync(rede);
        await _context.Set<Domain.Entity.Rede>().AddAsync(rede2);
        await _context.SaveChangesAsync();


        var redesDb = await RedeRepository.ObterTodos();
        
        Assert.Equal(2, redesDb.Count());
    }

    [Fact]
    public async Task DeveAlterarRedeComUnidadesEDiaVencimentos()
    {
        RedeDbContext _context = _fixture.CreateDbContext();
        var RedeRepository = new Rede.Data.EF.Repository.RedeRepository(_context);
        // Criando uma Rede
        var rede = _fixture.GetRede();
        var nomeAntigo = rede.RZ_SOCIAL;
        
        await _context.Set<Domain.Entity.Rede>().AddAsync(rede);
        await _context.SaveChangesAsync();
        var redeDb = await _context.Set<Domain.Entity.Rede>().FirstOrDefaultAsync(r => r.Id == rede.Id);

        string nomeNomeRazaoSocial = "nome novo";
        redeDb.RZ_SOCIAL = nomeNomeRazaoSocial;
        
        await RedeRepository.Editar(redeDb,CancellationToken.None);
        
        Assert.Equal(nomeNomeRazaoSocial, redeDb.RZ_SOCIAL);
        Assert.NotEqual(redeDb.RZ_SOCIAL, nomeAntigo);
    }
}