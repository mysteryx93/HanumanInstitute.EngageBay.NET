namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides common API endpoints for all objects with update methods.
/// TOverride can be used to configure Live and Sandbox accounts with a common interface and different Field IDs.
/// </summary>
/// <typeparam name="T">The data object type deriving from ApiObject.</typeparam>
public interface IEngageBaseWrite<T> : IEngageBaseRead<T>
    where T : ApiObject
{
    // /// <summary>
    // /// Retrieves all the information for an existing object.
    // /// </summary>
    // /// <param name="id">The ID of the specific object.</param>
    // /// <returns>The selected object.</returns>
    // Task<T?> SelectAsync(string keyValue, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint will add a new object to your database. It can be used for any object type as long as the correct parameters are supplied. This endpoint allows duplication; if you want to avoid duplicates you should merge instead.
    /// </summary>
    /// <param name="value">An object containing the values to add.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The object after creation.</returns>
    Task<T> CreateAsync(T value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing object with given data.
    /// </summary>
    /// <param name="objectId">The ID of the object to update.</param>
    /// <param name="value">An object containing the values to update.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The object after update.</returns>
    Task<T> UpdateAsync(long objectId, T value, CancellationToken cancellationToken = default);
}
