namespace HanumanInstitute.EngageBayApi.Models;

public class ApiForm : ApiObject
{
    public string? Name { get; set; }
    public string? AliasName { get; set; }
    public long? OwnerId { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    [JsonPropertyName("formHtml")]
    public string? FormHtml { get; set; }
    public string? FormAttributes { get; set; }
    public bool? EnableWhitelabel { get; set; }
    public string? FormStyle { get; set; }
    public string? Version { get; set; }
    [JsonPropertyName("incentiveEmail")]
    public string? IncentiveEmail { get; set; }
    public string? Thumbnail { get; set; }
    [JsonPropertyName("formStats")]
    public IDictionary<string, long>? FormStats { get; set; }
}
