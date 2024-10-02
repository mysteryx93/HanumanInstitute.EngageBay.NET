namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageTasks" />
public class EngageTasks : EngageBaseDelete<ApiTask>, IEngageTasks
{
    public EngageTasks(EngageHttpClient apiClient) : 
        base(apiClient, "dev/api/panel/tasks")
    { }

    /// <inheritdoc />
    public Task<IList<ApiTask>> SelectListAsync(ApiTaskType? taskType = null, ApiTaskStatus? taskStatus = null, 
        SelectListOptions? options = null, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object?>()
            .AddIfHasValue("taskType", taskType)
            .AddIfHasValue("taskStatus", taskStatus);
        return SelectListBaseAsync(options, query, cancellationToken);
    }
}
