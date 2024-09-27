using System.Text.Json;
using T = HanumanInstitute.EngageBayApi.Models.ApiCompany;

namespace HanumanInstitute.EngageBayApi.Models;

public class ApiCompany : ApiObjectComplex
{
    public string? Name { get; set; }
    public string? NameSort { get; set; }
    public string? Url { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public IList<ApiTag>? Tags { get; set; }
    [JsonPropertyName("contactIds")]
    public IList<long>? ContactIds { get; set; }
    public string? EntityGroupName { get; set; }
    public long? OwnerId { get; set; }
    public ApiOwner? Owner { get; set; }
    [JsonPropertyName("importedEntity")]
    public bool? ImportedEntity { get; set; }
    [JsonPropertyName("forceCreate")]
    public bool? ForceCreate { get; set; }
    [JsonPropertyName("companyIds")]
    public IList<long>? CompanyIds { get; set; }

    public string? GetName() => GetPropertyValue("name", false);
    public T SetName(string? value) => SetPropertyValue<T>("name", value, ApiFieldType.Text, false);

    public string? GetUrl() => GetPropertyValue("url", false);
    public T SetUrl(string? value) => SetPropertyValue<T>("url", value, ApiFieldType.Text, false);

    public string? GetEmail() => GetPropertyValue("email", false);
    public T SetEmail(string? value) => SetPropertyValue<T>("email", value, ApiFieldType.Text, false);

    public string? GetPhone(string? subtype = null) => GetPropertyValue("phone", false, subtype);
    public ApiContact SetPhone(string? value, string? subtype = null) => SetPropertyValue<ApiContact>("phone", value, ApiFieldType.Text, false, subtype);

    public string? GetWebsite() => GetPropertyValue("website", false);
    public ApiContact SetWebsite(string? value) => SetPropertyValue<ApiContact>("website", value, ApiFieldType.Text, false);

    public string? GetCountry() => GetPropertyValue("country", false);
    public ApiContact SetCountry(string? value) => SetPropertyValue<ApiContact>("country", value, ApiFieldType.Text, false);

    public ApiAddress? GetAddress()
    {
        var value = GetPropertyValue("address", false);
        return value != null ? JsonSerializer.Deserialize<ApiAddress>(value) : null;   
    }
    public ApiContact SetAddress(ApiAddress? value) => 
        SetPropertyValue<ApiContact>("address", value == null ? null : JsonSerializer.Serialize(value), ApiFieldType.Text, false);
}
