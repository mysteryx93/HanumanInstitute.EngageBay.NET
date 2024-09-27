using System.Text.Json;
using T = HanumanInstitute.EngageBayApi.Models.ApiContact;

namespace HanumanInstitute.EngageBayApi.Models;

public class ApiContact : ApiObjectComplex
{
    public long? OwnerId { get; set; }
    public string? Name { get; set; }
    [JsonPropertyName("firstname")]
    public string? FirstName { get; set; }
    [JsonPropertyName("lastname")]
    public string? LastName { get; set; }
    [JsonPropertyName("fullname")]
    public string? FullName { get; set; }
    public string? NameSort { get; set; }
    public string? Email { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public string? Status { get; set; }
    public IList<ApiSource>? Sources { get; set; }
    [JsonPropertyName("companyIds")]
    public IList<long>? CompanyIds { get; set; }
    [JsonPropertyName("contactIds")]
    public IList<long>? ContactIds { get; set; }
    [JsonPropertyName("listIds")]
    public IList<long>? ListIds { get; set; }
    public ApiOwner? Owner { get; set; }
    public string? EntityGroupName { get; set; }
    public IList<ApiTag>? Tags { get; set; }
    [JsonPropertyName("broadcastIds")]
    public IList<long>? BroadcastIds { get; set; }
    [JsonPropertyName("openedLinks")]
    public IList<long>? OpenedLinks { get; set; }
    [JsonPropertyName("emailProperties")]
    public IList<long>? EmailProperties { get; set; }
    [JsonPropertyName("unsubscribeList")]
    public IList<long>? UnsubscribeList { get; set; }
    [JsonPropertyName("emailBounceStatus")]
    public IList<long>? EmailBounceStatus { get; set; }
    [JsonPropertyName("importedEntity")]
    public bool? ImportedEntity { get; set; }
    [JsonPropertyName("forceCreate")]
    public bool? ForceCreate { get; set; }
    [JsonPropertyName("forceUpdate")]
    public bool? ForceUpdate { get; set; }
    public long? Score { get; set; }
    
    public string? GetName() => GetPropertyValue("name", false);
    public T SetName(string? value) => SetPropertyValue<T>("name", value, ApiFieldType.Text, false);

    public string? GetLastName() => GetPropertyValue("last_name", false);
    public T SetLastName(string? value) => SetPropertyValue<T>("last_name", value, ApiFieldType.Text, false);

    public string? GetEmail(string? subtype = null) => GetPropertyValue("email", false, subtype);
    public T SetEmail(string? value, string? subtype = null) => SetPropertyValue<T>("email", value, ApiFieldType.Text, false, subtype);

    public string? GetRole() => GetPropertyValue("role", false);
    public T SetRole(string? value) => SetPropertyValue<T>("role", value, ApiFieldType.Text, false);

    public string? GetPhone(string? subtype = null) => GetPropertyValue("phone", false, subtype);
    public T SetPhone(string? value, string? subtype = null) => SetPropertyValue<T>("phone", value, ApiFieldType.Text, false, subtype);

    public string? GetWebsite() => GetPropertyValue("website", false);
    public T SetWebsite(string? value) => SetPropertyValue<T>("website", value, ApiFieldType.Text, false);

    public string? GetCountry() => GetPropertyValue("country", false);
    public T SetCountry(string? value) => SetPropertyValue<T>("country", value, ApiFieldType.Text, false);

    public ApiAddress? GetAddress()
    {
        var value = GetPropertyValue("address", false);
        return value != null ? JsonSerializer.Deserialize<ApiAddress>(value) : null;   
    }
    public T SetAddress(ApiAddress? value) => 
        SetPropertyValue<T>("address", value == null ? null : JsonSerializer.Serialize(value), ApiFieldType.Text, false);
}
