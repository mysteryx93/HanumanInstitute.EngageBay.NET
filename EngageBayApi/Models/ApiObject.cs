namespace HanumanInstitute.EngageBayApi.Models;

/// <summary>
/// Base class for all API typed objects providing common functions.
/// </summary>
public class ApiObject
{
    /// <summary>
    /// A unique ID representing the object.
    /// </summary>
    public long? Id { get; set; }
    /// <summary>
    /// When fetching by pages, use this cursor to request the next page.
    /// </summary>
    public string? Cursor { get; set; }
}
