﻿namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Companies objects.
/// </summary>
public interface IEngageCompanies : IEngageBaseComplex<ApiCompany>
{
    /// <summary>
    /// Retrieves the list of companies.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of companies.</returns>
    Task<IList<ApiCompany>> SelectListAsync(SelectListOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add contact to company using the contact's ID.
    /// </summary>
    /// <param name="companyId">The company ID to add to.</param>
    /// <param name="contactId">The contact ID to add.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    public Task AddContactAsync(long companyId, long contactId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add contact to company using the contact's email address.
    /// </summary>
    /// <param name="companyId">The company ID t add to.</param>
    /// <param name="contactEmail">The contact email to add.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    public Task AddContactAsync(long companyId, string contactEmail, CancellationToken cancellationToken = default);
}
