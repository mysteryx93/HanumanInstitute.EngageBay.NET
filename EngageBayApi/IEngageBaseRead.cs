namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides common API endpoints for all objects with read methods.
/// </summary>
/// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
public interface IEngageBaseRead<T> 
    where T : ApiObject
{
    /// <summary>
    /// Retrieves all the information for an existing object.
    /// </summary>
    /// <param name="id">The ID of the specific object.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The selected object.</returns>
    Task<T?> SelectAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of objects.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of objects.</returns>
    Task<IList<T>> SelectManyAsync(SelectManyOptions? options = null, CancellationToken cancellationToken = default);
}
