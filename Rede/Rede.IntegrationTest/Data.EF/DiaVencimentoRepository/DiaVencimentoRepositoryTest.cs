
using Microsoft.EntityFrameworkCore;
using Rede.Data.EF;
using Rede.Domain.Entity;

namespace Rede.IntegrationTest.Data.EF.DiaVencimentoRepository;

[Collection(nameof(DiaVencimentoRepositoryFixture))]
public class DiaVencimentoRepositoryTest
{
    private readonly DiaVencimentoRepositoryFixture _fixture;

    public DiaVencimentoRepositoryTest(DiaVencimentoRepositoryFixture fixture)
    {
        _fixture = fixture;
    }
    
    
    
    [Fact]
    public async Task AddDiaVencimento_ShouldAddEntityToDatabase()
    {
        // Arrange
            RedeDbContext _context = _fixture.CreateDbContext();

            var repository = new Rede.Data.EF.Repository.DiaVencimentoRepository(_context);
            var diaVencimento = _fixture.GetDiaVencimento();

            // Act
            await repository.AddDiaVencimento(diaVencimento, CancellationToken.None);
            await _context.SaveChangesAsync();

            // Assert
            var diaVencimentoDb = await _context.Set<DiaVencimento>().FirstOrDefaultAsync(d => d.Id == diaVencimento.Id);
            Assert.NotNull(diaVencimentoDb);
            Assert.Equal(diaVencimento.Dia, diaVencimentoDb.Dia);
    }
}