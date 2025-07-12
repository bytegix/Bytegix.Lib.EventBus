using Bytegix.Lib.EventBus.Abstractions;
using Bytegix.Lib.EventBus.Events;
using Bytegix.Lib.EventBus.Subscription;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bytegix.Lib.EventBus.Tests.Extensions.Microsoft.Extensions.DependencyInjection;
public class EventBusBuilderExtensionsTests
{
    private class TestEventBusBuilder : IEventBusBuilder
    {
        public IServiceCollection Services { get; } = new ServiceCollection();
    }

    private record TestEvent : IntegrationEvent { }
    private class TestHandler : IIntegrationEventHandler<TestEvent>
    {
        public Task Handle(TestEvent @event) => Task.CompletedTask;
    }

    [Fact]
    public void ConfigureJsonOptions_InvokesConfiguration()
    {
        // Arrange
        var builder = new TestEventBusBuilder();
        bool configured = false;

        // Act
        builder.ConfigureJsonOptions(options =>
        {
            options.WriteIndented = true;
            configured = true;
        });

        var provider = builder.Services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<EventBusSubscriptionInfo>>().Value;

        // Assert
        Assert.True(configured);
        Assert.True(options.JsonSerializerSettings.WriteIndented);
    }

    [Fact]
    public void AddSubscription_RegistersHandlerAndEventType()
    {
        // Arrange
        var builder = new TestEventBusBuilder();

        // Act
        builder.AddSubscription<TestEvent, TestHandler>();
        var provider = builder.Services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<EventBusSubscriptionInfo>>().Value;

        // Assert: Event type mapping
        Assert.True(options.EventTypes.ContainsKey(nameof(TestEvent)));
        Assert.Equal(typeof(TestEvent), options.EventTypes[nameof(TestEvent)]);

        // Assert: Handler registration (using KeyedServiceProvider if available)
        // For demonstration, check that the service is registered
        var handler = provider.GetService<IIntegrationEventHandler>();
        Assert.NotNull(handler);
    }
}
