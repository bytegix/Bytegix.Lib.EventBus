using Bytegix.Lib.EventBus.Events;

namespace Bytegix.Lib.EventBus.Abstractions;
public interface IIntegrationDeadLetterEventHandler<in TIntegrationEvent> : IIntegrationDeadLetterEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);

    Task IIntegrationDeadLetterEventHandler.Handle(IntegrationEvent @event) => Handle((TIntegrationEvent)@event);
}

public interface IIntegrationDeadLetterEventHandler
{
    Task Handle(IntegrationEvent @event);
}
