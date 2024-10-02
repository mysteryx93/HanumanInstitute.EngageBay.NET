namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Tag objects.
/// </summary>
public class EngageTags : IEngageTags
{
    protected EngageHttpClient ApiClient { get; }

    public EngageTags(EngageHttpClient apiClient)
    {
        ApiClient = apiClient;
    }
    
    /// <inheritdoc />
    public Task<IList<ApiTag>> SelectListAsync(CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<IList<ApiTag>>("dev/api/panel/tags", null, false, cancellationToken)!;

    /// <inheritdoc />
    public Task AddAsync(string tagName, CancellationToken cancellationToken = default)
    {
        var tag = new ApiTag { Tag = tagName };
        return ApiClient.PostAsync("dev/api/panel/tags", tag, true, cancellationToken);
    }
}
