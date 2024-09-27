namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Contact objects.
/// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
/// </summary>
public interface IEngageContacts : IEngageBaseComplex<ApiContact>
{
    /// <summary>
    /// Returns data for a single contact by contact email.
    /// </summary>
    /// <param name="email">The email address of the contact.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The requested contact object, if found.</returns>
    Task<ApiContact?> SelectAsync(string email, CancellationToken cancellationToken = default);
}
