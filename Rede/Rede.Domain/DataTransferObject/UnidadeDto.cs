namespace Rede.Domain.DataTransferObject;

public class UnidadeDto
{
    public Guid id { get; set; }
    public string endereco { get; set; }
    public string numero { get; set; }
    public string complemento { get; set; }
    public string cep { get; set; }
}