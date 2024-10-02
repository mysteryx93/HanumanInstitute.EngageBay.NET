namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Products objects.
/// </summary>
public interface IEngageProducts : IEngageBaseComplex<ApiProduct>
{
    /// <summary>
    /// Returns a product by name.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The matching product.</returns>
    Task<ApiProduct?> SelectAsync(string name, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves the list of products.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of products.</returns>
    Task<IList<ApiProduct>> SelectListAsync(SelectListOptions? options = null, CancellationToken cancellationToken = default);
}
