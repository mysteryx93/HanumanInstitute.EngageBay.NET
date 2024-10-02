namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for CustomField objects.
/// </summary>
public interface IEngageCustomFields
{
    /// <summary>
    /// Retrieves the list of CustomFields. 
    /// </summary>
    /// <param name="type">The type of object to retrieve custom fields for.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of custom fields.</returns>
    Task<IList<ApiCustomField>> SelectListAsync(ApiCustomFieldType type, CancellationToken cancellationToken = default);
}
