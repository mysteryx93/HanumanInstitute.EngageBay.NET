namespace HanumanInstitute.EngageBayApi.Models;

public class ApiBroadcast
{
    [JsonPropertyName("emailIds")]
    public IList<string>? EmailIds { get; set; }
    public long? TemplateId { get; set; }
    public string? FromEmail { get; set; }
}
