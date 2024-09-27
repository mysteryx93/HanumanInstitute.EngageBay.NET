namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="EngageBaseComplex{T}"/>
public abstract class EngageBaseComplex<T> : EngageBaseDelete<T>, IEngageBaseComplex<T>
    where T : ApiObject
{
    protected EngageBaseComplex(EngageHttpClient apiClient, string endpoint, string endpointSingular) :
        base(apiClient, endpoint)
    {
        _endpointSingular = endpointSingular;
    }

    private readonly string _endpointSingular;

    protected override string CreateEndpoint => "/" + _endpointSingular;
    protected override string UpdateEndpoint => "/update-partial";

    /// <inheritdoc />
    public async Task<IList<T>> SearchAsync(string value, int? pageSize = null, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>
        {
            { "q", value },
            { "type", FirstCharToUpper(_endpointSingular) },
            { "page_size", pageSize }
        };

        var json = await ApiClient.GetJsonAsync(
            "dev/api/search", query, false, cancellationToken);
        return json.ParseList<T>();
    }

    private static string FirstCharToUpper(string input) =>
        string.IsNullOrEmpty(input) ? input : string.Concat(input[0].ToString().ToUpper(), input.Substring(1)); 
}
