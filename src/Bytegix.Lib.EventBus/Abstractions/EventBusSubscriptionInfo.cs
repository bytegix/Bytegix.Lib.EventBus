using System.Text.Json;

namespace Bytegix.Lib.EventBus.Abstractions;

public class EventBusSubscriptionInfo
{
    public Dictionary<string, Type> EventTypes { get; } = [];
    public Dictionary<string, Type> DeadLetterEventTypes { get; } = [];

    public JsonSerializerOptions JsonSerializerOptions { get; } = new();
}
