namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Tracks objects.
/// </summary>
public interface IEngageTracks : IEngageBaseDelete<ApiTrack>
{
    /// <summary>
    /// Retrieves the list of Tracks. 
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of tracks.</returns>
    Task<IList<ApiTrack>> SelectListAsync(CancellationToken cancellationToken = default);
}
