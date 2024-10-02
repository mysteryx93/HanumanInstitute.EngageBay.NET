namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Contact objects.
/// Contact objects allow you to keep up-to-date records for all the contacts you are managing.
/// </summary>
public interface IEngageContacts : IEngageBaseComplex<ApiContact>
{
    /// <summary>
    /// Retrieves the list of contacts.
    /// </summary>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of contacts.</returns>
    Task<IList<ApiContact>> SelectListAsync(SelectListOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns data for a single contact by contact email.
    /// </summary>
    /// <param name="email">The email address of the contact.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The requested contact object, if found.</returns>
    Task<ApiContact?> SelectAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for the contact based on the given email address and adds the given tags to the contact. You can add multiple tags.
    /// </summary>
    /// <param name="email">The email address of the contact.</param>
    /// <param name="tags">The list of tags to add.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task AddTagsAsync(string email, IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for the contact based on the given contact ID and adds the given tags to the contact. You can add multiple tags.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="tags">The list of tags to add.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task AddTagsAsync(long contactId, IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for the contact based on the given email address and searches for the given tag in the contact's tag list.
    /// If there is a match, then it deletes that tag. You can delete multiple tags.
    /// </summary>
    /// <param name="email">The email address of the contact.</param>
    /// <param name="tags">The list of tags to remove.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task DeleteTagsAsync(string email, IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for the contact based on the given contact ID and searches for the given tag in the contact's tag list.
    /// If there is a match, then it deletes that tag. You can delete multiple tags.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="tags">The list of tags to remove.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task DeleteTagsAsync(long contactId, IEnumerable<string> tags, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all the tags for a contact.
    /// </summary>
    /// <param name="email">The email address of the contact.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of tags.</returns>
    Task<IList<ApiTag>?> ListTagsAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lists all the tags for a contact.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of tags.</returns>
    Task<IList<ApiTag>?> ListTagsAsync(long contactId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or change the score of the contact using the contact's email address.
    /// </summary>
    /// <param name="email">The email address of the contact.</param>
    /// <param name="score">The score value to set.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task AddScoreAsync(string email, int score, CancellationToken cancellationToken = default);

    /// <summary>
    /// Change contact owner using owner email and contact ID.
    /// </summary>
    /// <param name="contactId">The ID of the contact to change.</param>
    /// <param name="ownerEmail">The email address of the new owner.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>The updated contact information.</returns>
    Task<ApiContact> ChangeOwnerAsync(long contactId, string ownerEmail, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint is used to create a group of contacts. Performance is optimal when the batch size is limited to 100 contacts or fewer.
    /// It an array of contacts and a callback URL to notify you after completion. The Callback URL field is optional here.
    /// </summary>
    /// <param name="contacts">The list of contacts to add.</param>
    /// <param name="callbackUrl">A URL that will be called after the operation is completed (optional).</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task<ApiStatus> BatchCreateAsync(IList<ApiContact> contacts, string? callbackUrl = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint is used to retrieve notes of contact by contact ID.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of notes.</returns>
    Task<IList<ApiNote>?> SelectNotesAsync(long contactId, SelectListOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint is used to retrieve call logs of contact by contact ID.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of call logs.</returns>
    Task<IList<ApiCallLog>?> SelectCallLogsAsync(long contactId, SelectListOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add contact to a form.
    /// </summary>
    /// <param name="email">The email of the contact.</param>
    /// <param name="formId">The form to add the contact to.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task AddToFormAsync(string email, long formId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add contact to a sequence.
    /// </summary>
    /// <param name="email">The email of the contact.</param>
    /// <param name="sequenceId">The sequence to add the contact to.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task AddToSequenceAsync(string email, long sequenceId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add contact to a list.
    /// </summary>
    /// <param name="email">The email of the contact.</param>
    /// <param name="listId">The list to add the contact to.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task AddToListAsync(string email, long listId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the list of all contact lists.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of contact lists.</returns>
    Task<IList<ApiTrack>> SelectListOfListsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a product to a contact.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="productId">The ID of the product to add.</param>
    /// <param name="subscribedOn">The date of the product subscription.</param>
    /// <param name="interval"></param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task<ApiContact> AddProductAsync(long contactId, long productId, DateTime? subscribedOn = null, string? interval = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a product from a contact.
    /// </summary>
    /// <param name="contactId">The ID of the contact.</param>
    /// <param name="productId">The ID of the product to remove.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task<ApiContact> RemoveProductAsync(long contactId, long productId, CancellationToken cancellationToken = default);
}
