namespace Usuario.Domain.Entity;

public class Usuario : SeedWork.Entity
{
    public Usuario(Guid id, string nmUsuario, DateTime dtNascimento, string nrCpf)
    {
        Id = id;
        NM_USUARIO = nmUsuario;
        DT_NASCIMENTO = dtNascimento;
        NR_CPF = nrCpf;
    }

    private string NM_USUARIO { get; set; }
    private DateTime DT_NASCIMENTO { get; set; }
    private string NR_CPF { get; set; }
    
    public ICollection<PerfilUnidade> PerfilUnidades { get; private set; } = new List<PerfilUnidade>();
}