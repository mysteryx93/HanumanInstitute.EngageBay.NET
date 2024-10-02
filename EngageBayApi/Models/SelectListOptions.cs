namespace HanumanInstitute.EngageBayApi.Models;

/// <summary>
/// Contains options for SelectMany standard methods.
/// </summary>
public class SelectListOptions
{
    /// <summary>
    /// Initializes a new instance of the SelectListOptions class.
    /// </summary>
    public SelectListOptions()
    { }

    /// <summary>
    /// Initializes a new instance of the SelectListOptions class with specified options.
    /// </summary>
    /// <param name="pageSize">How many objects to return per request.</param>
    /// <param name="sortKey">The column to sort the data on.</param>
    /// <param name="cursor">After a request, use the cursor to fetch the next page.</param>
    public SelectListOptions(int? pageSize = null, string? sortKey = null, string? cursor = null)
    {
        PageSize = pageSize;
        SortKey = sortKey;
        Cursor = cursor;
    }
    
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
