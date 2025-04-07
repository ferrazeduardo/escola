using Moq;
using Pessoa.Application.Interface;
using Pessoa.Application.Interface.Repository;
using Pessoa.Application.UseCase.AlunoUseCase.Save;
using Pessoa.Domain.Entity;

namespace Pessoa.UnitTest.Domain.UseCase.AlunoUseCase.Save;

[Collection(nameof(SaveAlunoTestFixture))]
public class SaveAlunoTest
{
    private readonly SaveAlunoTestFixture _fixture;
    private readonly Mock<IRedeRepository> _redeRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IPessoaRepository> _pessoRepository;

    public SaveAlunoTest(SaveAlunoTestFixture fixture)
    {
        _fixture = fixture;
        _redeRepository = _fixture.GetRedeRepositoryMock();
        _unitOfWork = _fixture.GetUnitOfWorkMock();
        _pessoRepository = _fixture.GetRepositoryMock();
    }
    
    [Fact(DisplayName = nameof(SaveAluno))]
    [Trait("UseCase","AlunoUseCase - Save")]
    public async Task SaveAluno()
    {
        var aluno = _fixture.GetExemploSaveAlunoInput();
        Rede rede = _fixture.GetRede(aluno.id_rede);
        Pai? pai = null;
        Mae? mae = null;
        _redeRepository.Setup(m => m.ObterPorId(aluno.id_rede)).ReturnsAsync(rede);
        _pessoRepository.Setup(m => m.ObterPeloCpf(It.IsAny<string>(),aluno.id_rede)).ReturnsAsync(pai);
        _pessoRepository.Setup(m => m.ObterPeloCpf(It.IsAny<string>(),aluno.id_rede)).ReturnsAsync(mae);

        var response = new SaveAluno(_pessoRepository.Object, _unitOfWork.Object,_redeRepository.Object);

        var output = await response.Handle(aluno,CancellationToken.None);
        
        _pessoRepository.Verify(
            repository => repository.Inserir(
                It.IsAny<Pessoa.Domain.SeedWorks.Pessoa>(),
                It.IsAny<CancellationToken>()
            ),
            Times.Exactly(3)
        );
        
        _unitOfWork.Verify(
            uow => uow.Commit(It.IsAny<CancellationToken>()),
            Times.Once
        );
        
        Assert.NotNull(output);
        Assert.NotNull(output.id);
        Assert.IsType<Guid>(output.id);
    }

    [Fact(DisplayName = nameof(SaveAlunoMaeJaExiste))]
    [Trait("UseCase","AlunoUseCase - Save")]
    public async Task SaveAlunoMaeJaExiste()
    {
        var aluno = _fixture.GetExemploSaveAlunoInput();
        Rede rede = _fixture.GetRede(aluno.id_rede);
        Pai? pai = null;
        Mae mae = _fixture.getMae(aluno);
        _redeRepository.Setup(m => m.ObterPorId(aluno.id_rede)).ReturnsAsync(rede);
        _pessoRepository.Setup(m => m.ObterPeloCpf(aluno.pai.cpf,aluno.id_rede)).ReturnsAsync(pai);
        _pessoRepository.Setup(m => m.ObterPeloCpf(aluno.mae.cpf,aluno.id_rede)).ReturnsAsync(mae);

        var response = new SaveAluno(_pessoRepository.Object, _unitOfWork.Object,_redeRepository.Object);

        var output = await response.Handle(aluno,CancellationToken.None);
        
        _pessoRepository.Verify(
            repository => repository.Inserir(
                It.IsAny<Pessoa.Domain.SeedWorks.Pessoa>(),
                It.IsAny<CancellationToken>()
            ),
            Times.Exactly(2)
        );
        
        _unitOfWork.Verify(
            uow => uow.Commit(It.IsAny<CancellationToken>()),
            Times.Once
        );
        
        Assert.NotNull(output);
        Assert.NotNull(output.id);
        Assert.IsType<Guid>(output.id);
    }

    [Fact(DisplayName = nameof(SaveAlunoPaiJaExiste))]
    [Trait("UseCase","AlunoUseCase - Save")]
    public async Task SaveAlunoPaiJaExiste()
    {
        var aluno = _fixture.GetExemploSaveAlunoInput();
        Rede rede = _fixture.GetRede(aluno.id_rede);
        Pai? pai = _fixture.GetPai(aluno);
        Mae mae = null;
        _redeRepository.Setup(m => m.ObterPorId(aluno.id_rede)).ReturnsAsync(rede);
        _pessoRepository.Setup(m => m.ObterPeloCpf(aluno.pai.cpf,aluno.id_rede)).ReturnsAsync(pai);
        _pessoRepository.Setup(m => m.ObterPeloCpf(aluno.mae.cpf,aluno.id_rede)).ReturnsAsync(mae);

        var response = new SaveAluno(_pessoRepository.Object, _unitOfWork.Object,_redeRepository.Object);

        var output = await response.Handle(aluno,CancellationToken.None);
        
        _pessoRepository.Verify(
            repository => repository.Inserir(
                It.IsAny<Pessoa.Domain.SeedWorks.Pessoa>(),
                It.IsAny<CancellationToken>()
            ),
            Times.Exactly(2)
        );
        
        _unitOfWork.Verify(
            uow => uow.Commit(It.IsAny<CancellationToken>()),
            Times.Once
        );
        
        Assert.NotNull(output);
        Assert.NotNull(output.id);
        Assert.IsType<Guid>(output.id);
    }

    [Fact(DisplayName = nameof(SaveAlunoPaiMaeJaExistem))]
    [Trait("UseCase","AlunoUseCase - Save")]
    public async Task SaveAlunoPaiMaeJaExistem()
    {
        var aluno = _fixture.GetExemploSaveAlunoInput();
        Rede rede = _fixture.GetRede(aluno.id_rede);
        Pai? pai = _fixture.GetPai(aluno);
        Mae mae = _fixture.getMae(aluno);
        _redeRepository.Setup(m => m.ObterPorId(aluno.id_rede)).ReturnsAsync(rede);
        _pessoRepository.Setup(m => m.ObterPeloCpf(aluno.pai.cpf,aluno.id_rede)).ReturnsAsync(pai);
        _pessoRepository.Setup(m => m.ObterPeloCpf(aluno.mae.cpf,aluno.id_rede)).ReturnsAsync(mae);

        var response = new SaveAluno(_pessoRepository.Object, _unitOfWork.Object,_redeRepository.Object);

        var output = await response.Handle(aluno,CancellationToken.None);
        
        _pessoRepository.Verify(
            repository => repository.Inserir(
                It.IsAny<Pessoa.Domain.SeedWorks.Pessoa>(),
                It.IsAny<CancellationToken>()
            ),
            Times.Exactly(1)
        );
        
        _unitOfWork.Verify(
            uow => uow.Commit(It.IsAny<CancellationToken>()),
            Times.Once
        );
        
        Assert.NotNull(output);
        Assert.NotNull(output.id);
        Assert.IsType<Guid>(output.id);
    }
}