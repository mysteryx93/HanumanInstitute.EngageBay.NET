namespace HanumanInstitute.EngageBayApi.Models;

public enum ApiFieldType
{
    [JsonPropertyName("TEXT")]
    Text,
    [JsonPropertyName("DATE")]
    Date,
    [JsonPropertyName("LIST")]
    List,
    [JsonPropertyName("CHECKBOX")]
    Checkbox,
    [JsonPropertyName("TEXTAREA")]
    TextArea,
    [JsonPropertyName("NUMBER")]
    Number,
    Currency,
    [JsonPropertyName("MULTICHECKBOX")]
    MultiCheckbox,
    [JsonPropertyName("URL")]
    Url,
    [JsonPropertyName("PHONE")]
    Phone,
    [JsonPropertyName("FILE")]
    File
}
