using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using Rede.Application.EventHandlers;
using Rede.Domain.Events;
using IMessageProducer = Rede.Domain.Interfaces.Application.IMessageProducer;

namespace Rede.Test.UnitTest.Application.EventHandlers;

public class SendToEnconderEventHandlerTest
{
    [Fact(DisplayName = nameof(HandleAsync))]
    [Trait("Application ", "EventHandlers")]
    public async Task HandleAsync()
    {
        var messageProducerMock = new Mock<IMessageProducer>();
        messageProducerMock.Setup(x => x.SendMessageAsync(It.IsAny<RedeSalvarEvent>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        var handler = new SendNovaRedeEventHandler(messageProducerMock.Object);
        RedeSalvarEvent @event = new RedeSalvarEvent("Razao social Teste", Guid.NewGuid());
        
        await handler.Handle(@event,CancellationToken.None);
        messageProducerMock.Verify(x => x.SendMessageAsync(@event, It.IsAny<CancellationToken>()), Times.Once);
    }
}