using System.Text.Json.Serialization;
using MediatR;

namespace Rede.Application.UseCases.RedeUseCase.Save;

public class SaveRedeInput : IRequest<SaveRedePayload>
{
        public string razaoSocial { get; set; }
        public string cnpj { get; set; }
        public List<int> diasVencimentoRede { get; set; }
        
        [JsonIgnore]
        public int codigoUsuario { get; set; }
}