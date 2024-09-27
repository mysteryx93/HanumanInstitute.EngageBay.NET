using System.Web;

namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageContacts"/>
public class EngageContacts : EngageBaseComplex<ApiContact>, IEngageContacts
{
    public EngageContacts(EngageHttpClient apiClient) : 
        base(apiClient, "dev/api/panel/subscribers", "subscriber")
    { }
    
    /// <inheritdoc />
    public async Task<ApiContact?> SelectAsync(string email, CancellationToken cancellationToken = default)
    {
        var json = await ApiClient.GetJsonAsync(
            $"{Endpoint}/contact-by-email/{HttpUtility.UrlEncode(email)}", cancellationToken: cancellationToken);
        return json.Parse<ApiContact>();
        // return await json.RunAndCatchAsync(OnParseSelect);
    }

    public async Task AddTagsAsync(string email, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        var query = new
        {
            email = email,
            tags = tags
        };
        await ApiClient.PostJsonAsync(
            $"{Endpoint}/email/tags/add", query, cancellationToken: cancellationToken);
    }
    
    public async Task DeleteTagsAsync(string email, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        var query = new
        {
            email = email,
            tags = tags
        };
        await ApiClient.PostJsonAsync(
            $"{Endpoint}/email/tags/delete", query, cancellationToken: cancellationToken);
    }
    
    public async Task<IList<ApiTag>?> ListTagsAsync(string email, CancellationToken cancellationToken = default)
    {
        var json = await ApiClient.GetJsonAsync(
            $"{Endpoint}/get-tags/{HttpUtility.UrlEncode(email)}", cancellationToken: cancellationToken);
        return json.ParseList<ApiTag>();
        // return await json.RunAndCatchAsync(OnParseSelectMultipleAsync<ApiTag>);
    }
}
