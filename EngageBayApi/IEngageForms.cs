namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Form objects.
/// </summary>
public interface IEngageForms
{
    /// <summary>
    /// Retrieves the list of Forms. 
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of forms.</returns>
    Task<IList<ApiForm>> SelectListAsync(CancellationToken cancellationToken = default);
}
