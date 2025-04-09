using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.UnidadeUseCase.AddUnidade;

public class AddUnidade : IRequestHandler<AddUnidadeInput, AddUnidadePayload>
{
    private readonly IRedeRepository _redeRepository;

    public AddUnidade(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
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

    //    await _redeRepository.AddUnidade(rede.Id, unidade);

        AddUnidadePayload output = new();
        output.id_unidade = unidade.Id;
        
        return output;
    }
}