namespace HanumanInstitute.EngageBayApi;

public static class SelectManyOptionsExtensions
{
    /// <summary>
    /// Converts SelectManyOptions into a dictionary of parameters.
    /// </summary>
    /// <param name="options">The options to get the query parameters for.</param>
    /// <returns>A dictionary of query parameters.</returns>
    public static IDictionary<string, object?> ToQuery(this SelectManyOptions? options)
    {
        options ??= new SelectManyOptions();
        return new Dictionary<string, object?>()
            .AddIfHasValue("page_size", options.PageSize)
            .AddIfHasValue("sort_key", options.SortKey)
            .AddIfHasValue("cursor", options.Cursor);
    }
}
