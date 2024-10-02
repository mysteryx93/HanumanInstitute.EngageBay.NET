using System.Web;

namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageProducts" />
public class EngageProducts : EngageBaseComplex<ApiProduct>, IEngageProducts
{
    public EngageProducts(EngageHttpClient apiClient) : 
        base(apiClient, "dev/api/panel/products", "product")
    { }

    /// <inheritdoc />
    public Task<ApiProduct?> SelectAsync(string name, CancellationToken cancellationToken = default) =>
        ApiClient.GetAsync<ApiProduct>($"{Endpoint}/getByName/{Uri.EscapeDataString(name)}", cancellationToken: cancellationToken);
    
    /// <summary>
    /// Retrieves the list of companies.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of companies.</returns>
    public Task<IList<ApiProduct>> SelectListAsync(SelectListOptions? options = null, CancellationToken cancellationToken = default) =>
        SelectListBaseAsync(options, null, cancellationToken);

    
}
