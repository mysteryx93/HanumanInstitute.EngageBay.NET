namespace HanumanInstitute.EngageBayApi.Models;

public class ApiMilestone
{
    [JsonPropertyName("labelName")]
    public string? LabelName { get; set; }
    [JsonPropertyName("labelActualName")]
    public string? LabelActualName { get; set; }
    [JsonPropertyName("isWon")]
    public bool? IsWon { get; set; }
    [JsonPropertyName("isLost")]
    public bool? IsLost { get; set; }
    public string? Color { get; set; }
    public double? Probability { get; set; }
}
