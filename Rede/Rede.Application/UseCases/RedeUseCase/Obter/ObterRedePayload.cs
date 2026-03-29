using Rede.Domain.DataTransferObject;
using Rede.Domain.Entity;

namespace Rede.Application.UseCases.RedeUseCase.Obter;

public class ObterRedeOutput
{
     public int id { get; set; }
    public string razaoSocial { get; set; }
    public string cnpj { get; set; }
    public string status { get; set; }
    public List<UnidadeDto>? Unidades { get; set; }
    public List<DiaVencimentoDto>? DiaVencimentos { get; set; }
   
}