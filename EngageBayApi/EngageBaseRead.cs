using System.Text.Json;

namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc />
public abstract class EngageBaseRead<T> : IEngageBaseRead<T>
    where T : ApiObject
{
    protected EngageHttpClient ApiClient { get; }
    protected string Endpoint { get; }

    protected EngageBaseRead(EngageHttpClient apiClient, string endpoint)
    {
        this.ApiClient = apiClient;
        Endpoint = endpoint;
    }

    /// <inheritdoc />
    public Task<T?> SelectAsync(long id, CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<T>($"{Endpoint}/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieves a list of objects.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="queryParams">Additional parameters to send with the select query.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of objects.</returns>
    protected Task<IList<T>> SelectListBaseAsync(SelectListOptions? options = null, IDictionary<string, object?>? queryParams = null, CancellationToken cancellationToken = default) =>
        ApiClient.PostAsync<IList<T>>($"{Endpoint}", options.ToQuery().AddObject(queryParams), false, cancellationToken);
}
