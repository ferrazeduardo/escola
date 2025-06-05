using RabbitMQ.Client;

namespace Rede.Messaging.Configuration;

public class ChannelManager
{
    private readonly IConnection _connection;
    private IModel? _channel = null;
    private readonly object _lock = new();
    public ChannelManager(IConnection connection)
    {
        _connection = connection;
    }

    public IModel GetChannel()
    {
        lock (_lock)
        {
            if (_channel == null || _channel.IsClosed)
            {
                 _channel = _connection.CreateModel();
            }
           return  _channel;
        }
    }
}