using System;
using Usuario.Domain.DataTransferObject;

namespace Usuario.Domain.Entity;

public class Rede : SeedWork.Entity
{
    public int Id { get; set; }
    public string DS_REDE { get; set;}


    public Rede FromRedeDto(RedeDto redeDto)
    {
        Id = redeDto.id;
        DS_REDE = redeDto.razaoSocial;
        return this;
    }

    public ICollection<UsuarioRede> usuarioRedes { get; private set; }
    public ICollection<Usuario> usuarios { get; private set; }
}
