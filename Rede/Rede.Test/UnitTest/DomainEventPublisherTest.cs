using Microsoft.Extensions.DependencyInjection;
using Moq;
using Rede.Application;
using Rede.Domain.SeedWork;

namespace Rede.Test.UnitTest;

public class DomainEventPublisherTest
{
    
    [Fact(DisplayName = nameof(Publish))]
    [Trait("Application ","DomainEventPublisher")]
    public async Task Publish()
    {
        
        var serviceCollection = new ServiceCollection();
        var eventHandleMock1 = new Mock<IDomainEventHandler<DomainEventToBeHandleFake>>();
        var eventHandleMock2 = new Mock<IDomainEventHandler<DomainEventToBeHandleFake>>();
        var eventHandleMock3 = new Mock<IDomainEventHandler<DomainEventToNotBeHandledFake>>();
        
        serviceCollection.AddSingleton(eventHandleMock1.Object);
        serviceCollection.AddSingleton(eventHandleMock2.Object);
        serviceCollection.AddSingleton(eventHandleMock3.Object);
        
        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        var domainEventPublisher = new DomainEventPublisher(serviceProvider);
        var @event  = new DomainEventToBeHandleFake();
        
        await domainEventPublisher.Publish((dynamic)@event,CancellationToken.None);
        
        eventHandleMock1.Verify(x => x.Handle(@event, It.IsAny<CancellationToken>()), Times.Once);
        eventHandleMock2.Verify(x => x.Handle(@event, It.IsAny<CancellationToken>()), Times.Once);
        eventHandleMock3.Verify(x => x.Handle(It.IsAny<DomainEventToNotBeHandledFake>(), It.IsAny<CancellationToken>()), Times.Never);
    }
    
    [Fact(DisplayName = nameof(NaoPublicarQuandoNaoHouverEventos))]
    [Trait("Application ","DomainEventPublisher")]
    public async Task NaoPublicarQuandoNaoHouverEventos()
    {
        
        var serviceCollection = new ServiceCollection();
        var eventHandleMock1 = new Mock<IDomainEventHandler<DomainEventToNotBeHandledFake>>();
        var eventHandleMock2 = new Mock<IDomainEventHandler<DomainEventToNotBeHandledFake>>();
        
        serviceCollection.AddSingleton(eventHandleMock1.Object);
        serviceCollection.AddSingleton(eventHandleMock2.Object);
        
        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        var domainEventPublisher = new DomainEventPublisher(serviceProvider);
        var @event  = new DomainEventToBeHandleFake();
        
        await domainEventPublisher.Publish((dynamic)@event,CancellationToken.None);
        
        eventHandleMock1.Verify(x => x.Handle(It.IsAny<DomainEventToNotBeHandledFake>(), It.IsAny<CancellationToken>()), Times.Never);
        eventHandleMock2.Verify(x => x.Handle(It.IsAny<DomainEventToNotBeHandledFake>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}