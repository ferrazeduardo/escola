using System.Text.Json.Serialization;
using Rede.Domain.Entity;

namespace Rede.Domain.DataTransferObject;

public class RedeDto
{
    public Guid id { get; set; }
    public string razaoSocial { get; set; }
    public string cnpj { get; set; }
    public string status { get; set; }
    public List<UnidadeDto>? Unidades { get; set; }
    public List<DiaVencimentoDto>? DiaVencimentos { get; set; }
}