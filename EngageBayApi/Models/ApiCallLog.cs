namespace HanumanInstitute.EngageBayApi.Models;

public class ApiCallLog : ApiObject
{
    public DateTime? CreatedTime { get; set; }
    public long? ContactId { get; set; }
    public string? CallId { get; set; }
    public int? Duration { get; set; }
    public string? Status { get; set; }
    public string? StatusLegacy { get; set; }
    public string? ToNumber { get; set; }
    public string? FromNumber { get; set; }
    public string? AccountId { get; set; }
    public string? CallerType { get; set; }
    public DateTime? StartedAt { get; set; }
    public string? RecordingUrl { get; set; }
    [JsonPropertyName("isManualEntry")]
    public bool? IsManualEntry { get; set; }
    public long? OwnerId { get; set; }
    //public IList<ApiNote>? Notes { get; set; }
    public ApiNote? Note { get; set; }
    [JsonPropertyName("addNote")]
    public bool? AddNote { get; set; }
    [JsonPropertyName("forceUpdate")]
    public bool? ForceUpdate { get; set; }
    [JsonPropertyName("sendNotificationsTo")]
    public IList<int>? SendNotificationsTo { get; set; }
    [JsonPropertyName("isVoicemail")]
    public bool? IsVoicemail { get; set; }
    [JsonPropertyName("callType")]
    public string? CallType { get; set; }
    [JsonPropertyName("reflectStatus")]
    public bool? ReflectStatus { get; set; }
    public decimal? CallCost { get; set; }
    [JsonPropertyName("inActive")]
    public bool? InActive { get; set; }
}
