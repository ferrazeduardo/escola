namespace Usuario.Domain.Entity;

public class Usuario : SeedWork.Entity
{
    public Usuario(int id, string nmUsuario, DateTime dtNascimento, string nrCpf)
    {
        Id = id;
        NM_USUARIO = nmUsuario;
        DT_NASCIMENTO = dtNascimento;
        NR_CPF = nrCpf;
    }

    public Usuario()
    {
        
    }

    public string NM_USUARIO { get; private set; }
    public DateTime DT_NASCIMENTO { get; private set; }
    public string NR_CPF { get; private set; }
    public string SEG_SENHA {get; private set;}
    public string SALT { get; private set; }
    
    public List<Unidade> Unidades { get; set; }
    
}