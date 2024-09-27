namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="EngageBaseDelete{T}"/>
public abstract class EngageBaseDelete<T> : EngageBaseWrite<T>, IEngageBaseDelete<T>
    where T : ApiObject
{
    protected EngageBaseDelete(EngageHttpClient apiClient, string endpoint) :
        base(apiClient, endpoint)
    { }

    /// <inheritdoc />
    public virtual Task DeleteAsync(long id, CancellationToken cancellationToken = default) =>
        ApiClient.DeleteAsync<object>($"{Endpoint}/{id}", cancellationToken: cancellationToken);
}
