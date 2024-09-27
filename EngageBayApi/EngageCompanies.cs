namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageCompanies" />
public class EngageCompanies : EngageBaseComplex<ApiCompany>, IEngageCompanies
{
    public EngageCompanies(EngageHttpClient apiClient) : 
        base(apiClient, "dev/api/panel/companies", "company")
    { }

    /// <inheritdoc />
    public async Task AddContactAsync(long companyId, long contactId, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "companyId", companyId },
            { "contactId", contactId }
        };

        await ApiClient.PostAsync($"{Endpoint}/{companyId}/add-contact-by-contactId", query, false, cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task AddContactAsync(long companyId, string contactEmail, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "companyId", companyId },
            { "contactEmail", contactEmail }
        };

        await ApiClient.PostAsync($"{Endpoint}/{companyId}/add-contact-by-contactEmail", query, false, cancellationToken);
    }
}
