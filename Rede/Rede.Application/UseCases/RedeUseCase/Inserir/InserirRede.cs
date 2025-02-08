using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Inserir;

public class InserirRede : IRequestHandler<InserirRedeCommand, InserirRedeOutput>
{
    public Task<InserirRedeOutput> Handle(InserirRedeCommand request, CancellationToken cancellationToken)
    {
        Domain.Entity.Rede rede = new(request.descricao,request.cnpj,request.codigoUsuario);
        return null;
    }
}