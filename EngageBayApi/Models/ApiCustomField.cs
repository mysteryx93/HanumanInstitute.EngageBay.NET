namespace HanumanInstitute.EngageBayApi.Models;

public class ApiCustomField : ApiObject
{
    public ApiFieldType? FieldType { get; set; }
    public string? Version { get; set; }
    public string? FieldLabel { get; set; }
    public string? FieldLabelCaseSensitive { get; set; }
    [JsonPropertyName("saveSilent")]
    public bool? SaveSilent { get; set; }
    public string? FieldDescription { get; set; }
    public string? FieldData { get; set; }
    public bool? IsRequired { get; set; }
    public bool? IsSearchable { get; set; }
    [JsonPropertyName("showInFilter")]
    public bool? ShowInFilter { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public string? Scope { get; set; }
    public long? Position { get; set; }
    public string? FieldName { get; set; }
}
