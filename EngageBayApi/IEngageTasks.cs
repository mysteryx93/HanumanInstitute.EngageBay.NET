namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Task objects.
/// A task object is created when a task is assigned to a contact or other object.
/// </summary>
public interface IEngageTasks : IEngageBaseDelete<ApiTask>
{
    /// <summary>
    /// Retrieves the list of tasks.
    /// </summary>
    /// <param name="taskType">TODO, EMAIL or CALL.</param>
    /// <param name="taskStatus">'not_started','in_progress','waiting','completed','deferred')</param>
    /// <param name="options">Various options to add to the select request.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of tasks.</returns>
    Task<IList<ApiTask>> SelectListAsync(ApiTaskType? taskType = null, ApiTaskStatus? taskStatus = null,
        SelectListOptions? options = null, CancellationToken cancellationToken = default);
}
