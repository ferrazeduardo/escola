using System.Text.Json.Serialization;
using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Inserir;

public class InserirRedeCommand : IRequest<InserirRedeOutput>
{
        public string razaoSocial { get; set; }
        public string cnpj { get; set; }
        public List<int> diasVencimentoRede { get; set; }
        
        [JsonIgnore]
        public int codigoUsuario { get; set; }
}