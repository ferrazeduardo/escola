using System;
using Usuario.Domain.Entity;

namespace Usuario.Domain.Interface.HttpClients;

public interface IRedeClient
{
    Task<Rede> ObterRede(int id);
}
