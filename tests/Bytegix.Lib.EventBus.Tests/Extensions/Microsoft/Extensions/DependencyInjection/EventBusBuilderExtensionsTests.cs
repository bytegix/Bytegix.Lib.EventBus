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
            options.CheckAdditionalContent = true;
            configured = true;
        });

        var provider = builder.Services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<EventBusSubscriptionInfo>>().Value;

        // Assert
        Assert.True(configured);
        Assert.True(options.JsonSerializerSettings.CheckAdditionalContent);
    }
}
