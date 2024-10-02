namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Sends data to EngageBay by posting a SmartForm which can then perform additional actions. 
/// This can be used as an alternative to the API. The form post can be done from the client's browser or from the server.
/// </summary>
public interface IEngagePostForms
{
    /// <summary>
    /// Posts an EngageBay form with specified data from the server. This method does not lock the thread.
    /// </summary>
    /// <param name="formId">The EngageBay UID of the form.</param>
    /// <param name="formParams">The list of form data to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task ServerPostAsync(string formId, IDictionary<string, object?> formParams, CancellationToken cancellationToken = default);
}
