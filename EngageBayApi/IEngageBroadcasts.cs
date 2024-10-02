namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Broadcast objects.
/// </summary>
public interface IEngageBroadcasts
{
    /// <summary>
    /// Sends a broadcast to specified emails.
    /// </summary>
    /// <param name="emailIds">The email addresses to send to.</param>
    /// <param name="templateId">The email template to send.</param>
    /// <param name="fromEmail">The email address to send from. It should be a verified one in From Email address in Account Settings.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    Task BroadcastAsync(IList<string> emailIds, long templateId, string fromEmail, CancellationToken cancellationToken = default);
}
