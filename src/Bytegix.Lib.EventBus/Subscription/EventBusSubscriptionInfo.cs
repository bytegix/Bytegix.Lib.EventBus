using Newtonsoft.Json;

namespace Bytegix.Lib.EventBus.Subscription;
public class EventBusSubscriptionInfo
{
    public Dictionary<string, Type> EventTypes { get; } = [];

    public JsonSerializerSettings JsonSerializerSettings { get; } = new();
}
