namespace HanumanInstitute.EngageBayApi.Models;

public enum ApiTaskType
{
    [JsonPropertyName("TODO")]
    Todo,
    [JsonPropertyName("EMAIL")]
    Email,
    [JsonPropertyName("CALL")]
    Call
}
