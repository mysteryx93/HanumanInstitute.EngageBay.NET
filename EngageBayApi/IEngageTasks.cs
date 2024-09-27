namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Task objects.
/// A task object is created when a task is assigned to a contact or other object.
/// </summary>
public interface IEngageTasks : IEngageBaseRead<ApiTask>
{
    /// <summary>
    /// Retrieves a list of objects.
    /// </summary>
    /// <param name="taskType">TODO, EMAIL or CALL.</param>
    /// <param name="taskStatus">'not_started','in_progress','waiting','completed','deferred')</param>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of objects.</returns>
    Task<IList<ApiTask>> SelectManyAsync(ApiTaskType? taskType = null, ApiTaskStatus? taskStatus = null,
        SelectManyOptions? options = null, CancellationToken cancellationToken = default);
}
