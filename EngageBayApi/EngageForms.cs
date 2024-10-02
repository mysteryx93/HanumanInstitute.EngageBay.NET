namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Form objects.
/// </summary>
public class EngageForms : IEngageForms
{
    protected EngageHttpClient ApiClient { get; }

    public EngageForms(EngageHttpClient apiClient)
    {
        ApiClient = apiClient;
    }
    
    /// <inheritdoc />
    public Task<IList<ApiForm>> SelectListAsync(CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<IList<ApiForm>>("dev/api/panel/forms", null, false, cancellationToken)!;
}
