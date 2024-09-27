namespace HanumanInstitute.EngageBayApi.Models;

public enum ApiTaskStatus
{
    [JsonPropertyName("not_started")]
    NotStarted,
    [JsonPropertyName("in_progress")]
    InProgress,
    [JsonPropertyName("waiting")]
    Waiting,
    [JsonPropertyName("completed")]
    Completed,
    [JsonPropertyName("deferred")]
    Deferred
}
