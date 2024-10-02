namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Broadcast objects.
/// </summary>
public class EngageBroadcasts : IEngageBroadcasts
{
    protected EngageHttpClient ApiClient { get; }

    public EngageBroadcasts(EngageHttpClient apiClient)
    {
        ApiClient = apiClient;
    }

    /// <inheritdoc />
    public Task BroadcastAsync(IList<string> emailIds, long templateId, string fromEmail, CancellationToken cancellationToken = default)
    {
        var broadcast = new ApiBroadcast
        {
            EmailIds = emailIds,
            TemplateId = templateId,
            FromEmail = fromEmail
        };
        return ApiClient.PostAsync("dev/api/panel/bulk-actions/broadcast", broadcast, true, cancellationToken);
    }
}
