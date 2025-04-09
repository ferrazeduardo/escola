using MediatR;
using Rede.Application.UseCases.UnidadeUseCase.AddUnidade;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.DiaVencimentoUseCase.AddDiaVencimento;
 
public class AddDiaVencimento : IRequestHandler<AddDiaVencimentoInput, AddDiaVEncimentoPayload>
{
    private readonly IRedeRepository _redeRepository;

    public AddDiaVencimento(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
    }
    
    public async Task<AddDiaVEncimentoPayload> Handle(AddDiaVencimentoInput request, CancellationToken cancellationToken)
    {
        AddDiaVEncimentoPayload payload = new AddDiaVEncimentoPayload();
        Domain.Entity.Rede rede = await _redeRepository.ObterPorId(request.id_rede);

        if (rede is null) throw new Exception("Rede não existe");

        foreach (var dia in request.diaVencimento)
        {
            DiaVencimento diaVencimento = new DiaVencimento();
            diaVencimento.Dia = dia;
          //  await _redeRepository.AddDiaVencimento(rede.Id, diaVencimento);
            payload.vencimentos.Add(diaVencimento.Dia);
        }
        

        return payload;
    }
}