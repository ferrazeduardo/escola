using System.Text.Json.Serialization;
using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Save;

public record SaveRedeInput(string razaoSocial, string cnpj) : IRequest<SaveRedePayload>
{
}