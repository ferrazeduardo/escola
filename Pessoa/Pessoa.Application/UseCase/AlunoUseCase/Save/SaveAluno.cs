using MediatR;
using Pessoa.Application.Interface;
using Pessoa.Application.Interface.Repository;
using Pessoa.Domain.Entity;

namespace Pessoa.Application.UseCase.AlunoUseCase.Save;

public class SaveAluno : IRequestHandler<SaveAlunoInput, SaveAlunoPayload>
{
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedeRepository _redeRepository;

    public SaveAluno(IPessoaRepository pessoaRepository,IUnitOfWork unitOfWork,IRedeRepository redeRepository)
    {
        _pessoaRepository = pessoaRepository;
        _unitOfWork = unitOfWork;
        _redeRepository = redeRepository;
    }
    
    
    public async Task<SaveAlunoPayload> Handle(SaveAlunoInput request, CancellationToken cancellationToken)
    {
        var aluno = GerarAluno(request);
        var mae = GerarMae(request, aluno);
        var pai = GerarPai(request, aluno);

        Rede rede = await _redeRepository.ObterPorId(request.id_rede);
        mae.SetRede(rede);
        pai.SetRede(rede);
        aluno.SetRede(rede);
        
        aluno.SetMae(mae);
        aluno.SetPai(pai);

        // var paiJaExiste = await _pessoaRepository.ObterPeloCpf(pai.NR_CPF,);
        // var maeJaExiste = await _pessoaRepository.ObterPeloCpf(mae.NR_CPF);
        //
        // if (paiJaExiste == null)
        //     await _pessoaRepository.Inserir(aluno.Pai,cancellationToken);
        //
        // if(maeJaExiste == null)
        //     await _pessoaRepository.Inserir(aluno.Mae,cancellationToken);
        
        await _pessoaRepository.Inserir(aluno,cancellationToken);

        _unitOfWork.Commit(cancellationToken);
        SaveAlunoPayload saveAlunoPayload = new();
        saveAlunoPayload.id = aluno.Id;
        return saveAlunoPayload;
    }

    private Pai GerarPai(SaveAlunoInput request, Aluno aluno)
    {
        Pai pai = new(NM_NOME: request.pai.nome, NR_CPF: request.pai.cpf, NR_RG: request.pai.rg,
            DS_ENDERECO: request.pai.endereco, NR_ENDERECO: request.pai.numero, UF: request.pai.uf,
            DT_NASCIMENTO: request.pai.dataNascimento);
        request.mae.telefones.ForEach(telefone => pai.AddTelefone(new Telefone(aluno.Id, telefone)));
        
        return pai;
    }

    private Mae GerarMae(SaveAlunoInput request, Aluno aluno)
    {
        Mae mae = new(NM_NOME: request.mae.nome, NR_CPF: request.mae.cpf, NR_RG: request.mae.rg,
            DS_ENDERECO: request.mae.endereco, NR_ENDERECO: request.mae.numero, UF: request.mae.uf,
            DT_NASCIMENTO: request.mae.dataNascimento);
        request.mae.telefones.ForEach(telefone => mae.AddTelefone(new Telefone(aluno.Id, telefone)));
        return mae;
    }

    private Aluno GerarAluno(SaveAlunoInput request)
    {
        Aluno aluno = new(NM_NOME: request.aluno.nome, NR_CPF: request.aluno.cpf, NR_RG: request.aluno.rg,
            DS_ENDERECO: request.aluno.endereco, NR_ENDERECO: request.aluno.numero, UF: request.aluno.uf,
            DT_NASCIMENTO: request.aluno.dataNascimento);
        request.aluno.telefones.ForEach(telefone => aluno.AddTelefone(new Telefone(aluno.Id, telefone)));
        return aluno;
    }
}