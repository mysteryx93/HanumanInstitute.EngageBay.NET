namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for users / owners.
/// </summary>
public class EngageUsers : IEngageUsers
{
    protected EngageHttpClient ApiClient { get; }

    public EngageUsers(EngageHttpClient apiClient)
    {
        ApiClient = apiClient;
    }
    
    /// <inheritdoc />
    public Task<IList<ApiOwner>> SelectOwnersListAsync(CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<IList<ApiOwner>>("dev/api/panel/users", null, false, cancellationToken)!;
    
    /// <inheritdoc />
    public Task<ApiOwner> SelectProfileAsync(CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<ApiOwner>("dev/api/panel/users/profile/user-info", null, false, cancellationToken)!;
}
