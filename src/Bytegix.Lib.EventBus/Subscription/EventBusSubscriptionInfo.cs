using System.Text.Json;

namespace Bytegix.Lib.EventBus.Subscription;

public class EventBusSubscriptionInfo
{
    public Dictionary<string, Type> EventTypes { get; } = [];

    public JsonSerializerOptions JsonSerializerSettings { get; } = new();
}
