namespace HanumanInstitute.EngageBayApi.Models;

public class ApiBatchContacts
{
    [JsonPropertyName("callbackURL")]
    public string? CallbackURL { get; set; }
    
    public IList<ApiContact> Contacts { get; set; }
}
