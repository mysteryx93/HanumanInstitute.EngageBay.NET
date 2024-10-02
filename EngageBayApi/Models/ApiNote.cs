namespace HanumanInstitute.EngageBayApi.Models;

public class ApiNote : ApiObject
{
    [JsonPropertyName("parentId")]
    public long? ParentId { get; set; }
    public string? Subject { get; set; }
    public string? Content { get; set; }
    public bool? Force { get; set; }
    [JsonPropertyName("syncIds")]
    public IList<int>? SyncIds { get; set; }
    public long? OwnerId { get; set; }
    public string? Type { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public string? Source { get; set; }
    [JsonPropertyName("createFollowUpTask")]
    public bool? CreateFollowUpTask { get; set; }
}
