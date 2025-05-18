using Rede.Domain.Events;

namespace Rede.Messaging.Configuration;

public class EventsMappeing
{
    private static Dictionary<string,string> _routingKeys = new Dictionary<string, string>()
    {
        {typeof(RedeSalvarEvent).Name,"rede.salvar"},
    };
    
    public  static string GetRoutingKey<T>() => _routingKeys[typeof(T).Name];
}