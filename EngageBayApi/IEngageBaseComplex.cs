namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides common API endpoints for all complex objects with extended properties.
/// </summary>
/// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
public interface IEngageBaseComplex<T> : IEngageBaseDelete<T>
    where T : ApiObject
{
    /// <summary>
    /// Search objects using keyword.
    /// </summary>
    /// <param name="value">The keyword to search for.</param>
    /// <param name="pageSize">How many objects to return.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of objects matching the search terms.</returns>
    public Task<IList<T>> SearchAsync(string value, int? pageSize = null, CancellationToken cancellationToken = default);
}
