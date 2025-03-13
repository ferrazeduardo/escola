namespace Pessoa.Domain.DataTransferObject;

public class PessoaDto
{
    public string nome { get; set; }
    public string cpf { get; set; }
    public string rg { get; set; }
    public string endereco { get; set; }
    public string cep { get; set; }
    public string numero { get; set; }
    public DateTime dataNascimento { get; set; }
    public string uf { get; set; }
}