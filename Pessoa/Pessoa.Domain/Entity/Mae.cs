namespace Pessoa.Domain.Entity;

public class Mae : SeedWorks.Pessoa
{
    public Mae(string NM_NOME,string NR_CPF, string NR_RG, string DS_ENDERECO,string NR_ENDERECO,string UF,DateTime DT_NASCIMENTO)
    {
        this.NM_NOME = NM_NOME;
        this.NR_CPF = NR_CPF;
        this.NR_RG = NR_RG;
        this.DS_ENDERECO = DS_ENDERECO;
        this.NR_ENDERECO = NR_ENDERECO;
        this.UF = UF;
        this.DT_NASCIMENTO = DT_NASCIMENTO;
        
        this.Validacao();
        this.ValidacaoMaiorDeIdade();
    }

   
}