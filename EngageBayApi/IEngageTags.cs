namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Tag objects.
/// </summary>
public interface IEngageTags
{
    /// <summary>
    /// Retrieves the list of Tags. 
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of tags.</returns>
    Task<IList<ApiTag>> SelectListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Add new tag to the account. It won't add duplicates if already exists.
    /// </summary>
    /// <param name="tagName">The new tag to create.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns></returns>
    Task AddAsync(string tagName, CancellationToken cancellationToken = default);
}
