namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageCustomFields" />
public class EngageCustomFields : IEngageCustomFields
{
    protected EngageHttpClient ApiClient { get; }

    public EngageCustomFields(EngageHttpClient apiClient)
    {
        ApiClient = apiClient;
    }

    /// <inheritdoc />
    public Task<IList<ApiCustomField>> SelectListAsync(ApiCustomFieldType type, CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<IList<ApiCustomField>>($"dev/api/panel/customfields/list/{type.ToString().ToUpper()}", null, false, cancellationToken)!;
}
