namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for users / owners.
/// </summary>
public interface IEngageUsers
{
    /// <summary>
    /// Retrieves the list of owners. 
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of owners.</returns>
    Task<IList<ApiOwner>> SelectOwnersListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the account profile.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The account profile.</returns>
    Task<ApiOwner> SelectProfileAsync(CancellationToken cancellationToken = default);
}
