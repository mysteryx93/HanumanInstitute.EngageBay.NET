namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageDeals" />
public class EngageDeals : EngageBaseComplex<ApiDeal>, IEngageDeals
{
    public EngageDeals(EngageHttpClient apiClient) : 
        base(apiClient, "dev/api/panel/deals", "deal")
    { }

    /// <summary>
    /// Retrieves the list of contacts.
    /// </summary>
    /// <param name="trackId">Track ID to list results on specific Track. If No track specified, Default track results will return.</param>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of contacts.</returns>
    public Task<IList<ApiDeal>> SelectListAsync(long? trackId = null, SelectManyOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddIfHasValue("track_id", trackId);
        return SelectListBaseAsync(options, query, cancellationToken);
    }

}
