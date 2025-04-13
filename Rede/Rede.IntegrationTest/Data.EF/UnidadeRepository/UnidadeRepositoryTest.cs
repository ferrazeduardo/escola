using Microsoft.EntityFrameworkCore;
using Rede.Data.EF;
using Rede.Domain.Entity;

namespace Rede.IntegrationTest.Data.EF.UnidadeRepository;

[Collection(nameof(UnidadeRepositoryFixture))]
public class UnidadeRepositoryTest
{
    private readonly UnidadeRepositoryFixture _fixture;

    public UnidadeRepositoryTest(UnidadeRepositoryFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    [Fact]
    public async Task AddUnidade_ShouldAddEntityToDatabase()
    {
        RedeDbContext _context = _fixture.CreateDbContext();

        var repository = new Rede.Data.EF.Repository.UnidadeRepository(_context);
        var rede = _fixture.GetRede();
        var unidade = _fixture.GetUnidade(rede);

        await _context.Set<Domain.Entity.Rede>().AddAsync(rede);
        await _context.SaveChangesAsync();
        await repository.AddUnidade(unidade, CancellationToken.None);
        await _context.SaveChangesAsync();
        
        var savedEntity = await _context.Set<Unidade>().FirstOrDefaultAsync(u => u.Id == unidade.Id);
        Assert.NotNull(savedEntity);
    }
}