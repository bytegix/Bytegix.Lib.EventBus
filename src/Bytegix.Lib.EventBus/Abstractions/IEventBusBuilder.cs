using Microsoft.Extensions.DependencyInjection;

namespace Bytegix.Lib.EventBus.Abstractions;

public interface IEventBusBuilder
{
    public IServiceCollection Services { get; }
}
