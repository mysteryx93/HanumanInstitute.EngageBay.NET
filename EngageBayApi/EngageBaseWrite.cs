namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageBaseWrite{T}"/>
public abstract class EngageBaseWrite<T> : EngageBaseRead<T>, IEngageBaseWrite<T>
    where T : ApiObject
{
    protected EngageBaseWrite(EngageHttpClient apiClient, string endpoint) :
        base(apiClient, endpoint)
    {
    }

    protected virtual string CreateEndpoint => "";

    /// <summary>
    /// This endpoint will add a new object to your database. It can be used for any object type as long as the correct parameters are supplied. This endpoint allows duplication; if you want to avoid duplicates you should merge instead.
    /// </summary>
    /// <param name="value">An object containing the values to add.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The created object.</returns>
    public async Task<T> CreateAsync(T value, CancellationToken cancellationToken = default)
    {
        var json = await ApiClient.PostJsonAsync(
            Endpoint + CreateEndpoint, value, true, cancellationToken);
        return json.Parse<T>();
    }

    /// <summary>
    /// Updates an existing object with given data.
    /// </summary>
    /// <param name="objectId">The ID of the object to update.</param>
    /// <param name="value">An object containing the values to update.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A dictionary of updated fields.</returns>
    public async Task<T> UpdateAsync(long objectId, T value, CancellationToken cancellationToken = default)
    {
        value.Id = objectId;
        var json = await ApiClient.PutJsonAsync(
            Endpoint + UpdateEndpoint, value, cancellationToken);
        return json.Parse<T>();
    }

    protected virtual string UpdateEndpoint => "";
}
