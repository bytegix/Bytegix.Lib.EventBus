using System.Text.Json.Serialization;

namespace Bytegix.Lib.EventBus.Events;
public record IntegrationEvent
{
    // Properties
    // ==============================
    [JsonInclude]
    public Guid Id { get; set; }

    [JsonInclude]
    public DateTime CreationDate { get; set; }

    // Constructors
    // ==============================
    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
}
