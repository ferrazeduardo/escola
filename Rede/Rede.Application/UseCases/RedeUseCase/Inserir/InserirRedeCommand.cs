using System.Text.Json.Serialization;
using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Inserir;

public class InserirRedeCommand : IRequest<InserirRedeOutput>
{
        public string descricao { get; set; }
        public string cnpj { get; set; }
        
        [JsonIgnore]
        public int codigoUsuario { get; set; }
}