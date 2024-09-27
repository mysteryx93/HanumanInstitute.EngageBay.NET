namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides common API endpoints for all objects with delete methods.
/// </summary>
/// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
public interface IEngageBaseDelete<T> : IEngageBaseWrite<T>
    where T : ApiObject
{
    /// <summary>
    /// Deletes an existing object.
    /// </summary>
    /// <param name="id">The ID of the specific object.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}
