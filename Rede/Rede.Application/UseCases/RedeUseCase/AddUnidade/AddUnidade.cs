using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Exception;
using Rede.Domain.Interfaces;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.AddUnidade;

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

        NotFounException.Object(rede, "Rede não existe");

        Unidade unidade = new Unidade(
            endereco: request.endereco,
            cep: request.cep,
            numeroUnidade: request.numeroUnidade,
            usuarioRegistro: request.usuarioRegistro,
            dsComplmento: request.complemento,
            rede: rede
        );

        List<Telefone> telefones = request.telefones.Select(GerarListaTelefone()).ToList();


        unidade.AddTelefoneRange(telefones);
        rede.AddUnidade(unidade);

        await _unitOfWork.Commit(cancellationToken);

        AddUnidadePayload output = new();
        output.id_unidade = unidade.Id;

        return output;
    }

    private static Func<string, Telefone> GerarListaTelefone()
    {
        return t => new Telefone
        {
            NR_TELEFONE = t
        };
    }
}