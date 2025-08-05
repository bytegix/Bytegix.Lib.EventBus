using System.Text.Json;

namespace Bytegix.Lib.EventBus.Abstractions;

public class EventBusSubscriptionInfo
{
    public Dictionary<string, Type> EventTypes { get; } = [];
    public Dictionary<string, Type> DeadLetterEventTypes { get; } = [];
    /// <summary>
    /// !!! IMPORTANT: All types in this collection will be ignored when processing messages from dead letetr queue
    /// which will result in message loss.
    /// </summary>
    public Dictionary<string, Type> IgnoreDeadLetterEventTypes { get; } = [];
    public JsonSerializerOptions JsonSerializerOptions { get; } = new();
}
