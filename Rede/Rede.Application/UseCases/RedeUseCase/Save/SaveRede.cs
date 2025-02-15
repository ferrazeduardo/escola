using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.Save;

public class SaveRede : IRequestHandler<SaveRedeCommand, SaveRedeOutput>
{
    private readonly IRedeRepository _redeRepository;

    public SaveRede(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
    }
    
    public async Task<SaveRedeOutput> Handle(SaveRedeCommand request, CancellationToken cancellationToken)
    {
        var diasVencimento = DiasVencimento(request);
        
        Domain.Entity.Rede rede = new(request.razaoSocial,request.cnpj,request.codigoUsuario,diasVencimento);
        
        await _redeRepository.Inserir(rede);

        SaveRedeOutput output = new();
        output.codigo = rede.Id;
        
        return output;
    }

    private static List<DiaVencimento> DiasVencimento(SaveRedeCommand request)
    {
        var diasVencimento = request.diasVencimentoRede.Select(dia => new DiaVencimento()
        {
            Dia = dia
        }).ToList();
        return diasVencimento;
    }
}