namespace HanumanInstitute.EngageBayApi.Models;

public class ApiTrack : ApiObject
{
    public string? Name { get; set; }
    public IList<ApiMilestone>? Milestones { get; set; }
    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }
    public DateTime? CreatedTime { get; set; }
}
