namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageDeals" />
public class EngageTracks : EngageBaseDelete<ApiTrack>, IEngageTracks
{
    public EngageTracks(EngageHttpClient apiClient) : 
        base(apiClient, "dev/api/panel/tracks")
    { }
    

    protected override string CreateEndpoint => "/track";
    protected override string UpdateEndpoint => "/track";

    /// <inheritdoc />
    public Task<IList<ApiTrack>> SelectListAsync(CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<IList<ApiTrack>>($"{Endpoint}", null, false, cancellationToken)!;
}
