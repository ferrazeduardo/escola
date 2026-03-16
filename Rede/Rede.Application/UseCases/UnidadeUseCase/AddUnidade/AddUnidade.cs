using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.UnidadeUseCase.AddUnidade;

public class AddUnidade : IRequestHandler<AddUnidadeInput, AddUnidadePayload>
{
    private readonly IRedeRepository _redeRepository;
    private readonly IUnidadeRepository _unidadeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUnidade(IRedeRepository redeRepository, IUnidadeRepository unidadeRepository, IUnitOfWork unitOfWork)
    {
        _redeRepository = redeRepository;
        _unidadeRepository = unidadeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddUnidadePayload> Handle(AddUnidadeInput request, CancellationToken cancellationToken)
    {
        Domain.Entity.Rede rede = await _redeRepository.ObterPorId(request.id_rede);

        if (rede is null) throw new Exception("Rede não existe");

        Unidade unidade = new Unidade();
        unidade.DS_ENDERECO = request.endereco;
        unidade.NR_CEP = request.cep;
        unidade.DH_REGISTRO = DateTime.Now;
        unidade.US_REGISTRO = request.codigoUsuario;
        unidade.NR_UNIDADE = request.numeroUnidade;
        unidade.DS_COMPLMENTO = request.complemento;
        unidade.Ativar();

        await _unidadeRepository.Inserir(unidade, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        AddUnidadePayload output = new();
        output.id_unidade = unidade.Id;

        return output;
    }
}