﻿using Bytegix.Lib.EventBus.Events;

namespace Bytegix.Lib.EventBus.Abstractions;

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);

    Task IIntegrationEventHandler.Handle(IntegrationEvent @event) => Handle((TIntegrationEvent)@event);
}

public interface IIntegrationEventHandler
{
    Task Handle(IntegrationEvent @event);
}
