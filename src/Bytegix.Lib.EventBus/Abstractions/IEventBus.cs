using Bytegix.Lib.EventBus.Events;

namespace Bytegix.Lib.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken = default);
}
