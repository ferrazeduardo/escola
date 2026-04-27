using System;
using domain = Usuario.Domain.Entity;

namespace Usuario.Domain.Interface.Service;

public interface ITokenService
{
    string GerarToken(domain.Usuario usuario);
}
