using System.Web;

namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageContacts"/>
public class EngageContacts : EngageBaseComplex<ApiContact>, IEngageContacts
{
    public EngageContacts(EngageHttpClient apiClient) :
        base(apiClient, "dev/api/panel/subscribers", "subscriber")
    {
    }

    /// <inheritdoc />
    public async Task<ApiContact?> SelectAsync(string email, CancellationToken cancellationToken = default)
    {
        return await ApiClient.GetAsync<ApiContact>(
            $"{Endpoint}/contact-by-email/{HttpUtility.UrlEncode(email)}", cancellationToken: cancellationToken);
    }
    
    /// <summary>
    /// Retrieves the list of contacts.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of contacts.</returns>
    public Task<IList<ApiContact>> SelectListAsync(SelectManyOptions? options = null, CancellationToken cancellationToken = default) =>
        SelectListBaseAsync(options, null, cancellationToken);

    /// <inheritdoc />
    public async Task AddTagsAsync(string email, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "email", email },
            { "tags", tags }
        };
        await ApiClient.PostAsync(
            $"{Endpoint}/email/tags/add", query, false, cancellationToken: cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task AddTagsAsync(long contactId, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        await ApiClient.PostAsync(
            $"{Endpoint}/contact/tags/add2/{contactId}", tags, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteTagsAsync(string email, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "email", email },
            { "tags", tags }
        };
        await ApiClient.PostAsync(
            $"{Endpoint}/email/tags/delete", query, false, cancellationToken: cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task DeleteTagsAsync(long contactId, IEnumerable<string> tags, CancellationToken cancellationToken = default)
    {
        await ApiClient.PostAsync(
            $"{Endpoint}/contact/tags/delete/{contactId}", tags, true, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IList<ApiTag>?> ListTagsAsync(string email, CancellationToken cancellationToken = default)
    {
        return await ApiClient.PostAsync<List<ApiTag>>(
            $"{Endpoint}/get-tags/{HttpUtility.UrlEncode(email)}", cancellationToken: cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task<IList<ApiTag>?> ListTagsAsync(long contactId, CancellationToken cancellationToken = default)
    {
        return await ApiClient.GetAsync<List<ApiTag>>(
            $"{Endpoint}/get-tags-by-id/{contactId}", cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddScoreAsync(string email, int score, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "email", email },
            { "score", score }
        };
        await ApiClient.PostAsync(
            $"{Endpoint}/add-score", query, false, cancellationToken: cancellationToken);
    }
    
    /// <inheritdoc />
    public Task<ApiContact> ChangeOwnerAsync(long contactId, string ownerEmail, CancellationToken cancellationToken = default) =>
        ApiClient.PostAsync<ApiContact>(
            $"{Endpoint}/update-owner-by-email?subscriberId={contactId}&ownerEmail={HttpUtility.UrlEncode(ownerEmail)}", cancellationToken: cancellationToken);
    
    /// <inheritdoc />
    public Task<ApiStatus> BatchCreateAsync(IList<ApiContact> contacts, string? callbackUrl = null, CancellationToken cancellationToken = default) =>
        ApiClient.PostAsync<ApiStatus>(Endpoint + "/subscriber-batch", new ApiBatchContacts
        {
            CallbackURL = callbackUrl,
            Contacts = contacts
        }, true, cancellationToken);
    
    /// <inheritdoc />
    public Task<IList<ApiNote>?> SelectNotesAsync(long contactId, SelectManyOptions? options = null, CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<IList<ApiNote>>($"dev/api/panel/notes/{contactId}", options.ToQuery(), cancellationToken: cancellationToken);

    /// <inheritdoc />
    public Task<IList<ApiCallLog>?> SelectCallLogsAsync(long contactId, SelectManyOptions? options = null, CancellationToken cancellationToken = default)
    {
        var query = options.ToQuery();
        query.Add("contact_id", contactId);
        return ApiClient.GetAsync<IList<ApiCallLog>>("dev/api/panel/call-logs", query, cancellationToken: cancellationToken);
    }
}
