namespace HanumanInstitute.EngageBayApi;

/// <inheritdoc cref="IEngageTasks" />
public class EngageTasks : EngageBaseDelete<ApiTask>, IEngageTasks
{
    public EngageTasks(EngageHttpClient apiRequest) : 
        base(apiRequest, "dev/api/panel/tasks")
    { }

    /// <inheritdoc />
    public Task<IList<ApiTask>> SelectManyAsync(ApiTaskType? taskType = null, ApiTaskStatus? taskStatus = null, 
        SelectManyOptions? options = null, CancellationToken cancellationToken = default)
    {
        options ??= new SelectManyOptions();
        options.Filters ??= new Dictionary<string, object?>();
        options.Filters
            .AddIfHasValue("taskType", taskType)
            .AddIfHasValue("taskStatus", taskStatus);
        return SelectManyAsync(options, cancellationToken);
    }
}
