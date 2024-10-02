namespace HanumanInstitute.EngageBayApi.Models;

/// <summary>
/// Contains options for SelectMany standard methods.
/// </summary>
public class SelectManyOptions
{
    /// <summary>
    /// Gets or sets the column to sort the data on.
    /// </summary>
    public string? SortKey { get; set; }
    /// <summary>
    /// Gets or sets how many objects to return per request.
    /// </summary>
    public int? PageSize { get; set; }
    /// <summary>
    /// After a request, use the cursor to fetch the next page.
    /// </summary>
    public string? Cursor { get; set; }
}
