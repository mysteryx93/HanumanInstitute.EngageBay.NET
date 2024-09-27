using System.Net.Http;
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
    public async Task<T?> SelectAsync(long id, CancellationToken cancellationToken = default)
    {
        var json = await ApiClient.GetJsonAsync(
            $"{Endpoint}/{id}", cancellationToken: cancellationToken);
        return json.Parse<T>();
    }

    /// <summary>
    /// When overriden in a derived class, allows custom parsing of SelectAsync response.
    /// </summary>
    /// <param name="json">The JSON data to parse.</param>
    /// <returns>A T or object derived from it.</returns>
    protected virtual T OnParseSelect(JsonElement json) => json.Parse<T>();

    /// <inheritdoc />
    public async Task<IList<T>> SelectManyAsync(SelectManyOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new SelectManyOptions();
        var query = new Dictionary<string, object?>()
            .AddObject(options.Filters)
            .AddIfHasValue("page_size", options.PageSize)
            .AddIfHasValue("sort_key", options.SortKey)
            .AddIfHasValue("cursor", options.Cursor);
    
        return await ApiClient.PostAsync<IList<T>>(
            $"{Endpoint}", query, false, cancellationToken);
    }

    /// <summary>
    /// When overriden in a derived class, allows custom parsing of SelectMultipleAsync response.
    /// </summary>
    /// <param name="json">The JSON data to parse.</param>
    /// <returns>A List{T} or object derived from it.</returns>
    protected virtual IList<TParse> OnParseSelectMultipleAsync<TParse>(JsonElement json) => json.ParseList<TParse>();
}
