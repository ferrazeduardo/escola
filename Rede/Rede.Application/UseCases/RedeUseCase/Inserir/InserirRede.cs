using MediatR;
using Rede.Domain.Entity;
using Rede.Domain.Interfaces.Repository;

namespace Rede.Application.UseCases.RedeUseCase.Inserir;

public class InserirRede : IRequestHandler<InserirRedeCommand, InserirRedeOutput>
{
    private readonly IRedeRepository _redeRepository;

    public InserirRede(IRedeRepository redeRepository)
    {
        _redeRepository = redeRepository;
    }
    
    public async Task<InserirRedeOutput> Handle(InserirRedeCommand request, CancellationToken cancellationToken)
    {
        var diasVencimento = DiasVencimento(request);
        
        Domain.Entity.Rede rede = new(request.razaoSocial,request.cnpj,request.codigoUsuario,diasVencimento);
        
        await _redeRepository.Inserir(rede);

        InserirRedeOutput output = new();
        output.codigo = rede.Id;
        
        return output;
    }

    private static List<DiaVencimento> DiasVencimento(InserirRedeCommand request)
    {
        var diasVencimento = request.diasVencimentoRede.Select(dia => new DiaVencimento()
        {
            Dia = dia
        }).ToList();
        return diasVencimento;
    }
}