using System.Collections;
using System.Net;
using System.Text.Json;

namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Facilitates building EngageBay queries by adding common parameters.
/// </summary>
internal static class DictionaryExtensions
{
    /// <summary>
    /// Adds a key-value pair to the dictionary if value is not null.
    /// </summary>
    /// <param name="list">The dictionary of query parameters.</param>
    /// <param name="key">The key to add.</param>
    /// <param name="value">The value to add if not null.</param>
    /// <returns>The query dictionary.</returns>
    internal static IDictionary<string, object?> AddIfHasValue(this IDictionary<string, object?> list, string key, object? value)
    {
        if (value != null)
        {
            list.Add(key, value);
        }
        return list;
    }

    /// <summary>
    /// Adds all properties of an object into the dictionary using reflection.
    /// If object is a Dictionary, its content will instead be added.
    /// </summary>
    /// <param name="list">The dictionary of query parameters.</param>
    /// <param name="values">An object containing the values to add.</param>
    /// <returns>The query dictionary.</returns>
    internal static IDictionary<string, object?> AddObject(this IDictionary<string, object?> list, object? values)
    {
        if (values != null)
        {
            if (values is IDictionary<string, object> objects)
            {
                objects.ToList().ForEach(x => list.Add(x.Key, x.Value));
            }
            else
            {
                // Object properties through reflection.
                var properties = values.GetType().GetProperties();
                foreach (var item in properties)
                {
                    var itemName = item.Name;
                    var itemValue = item.GetValue(values, null);
                    list.Add(itemName, itemValue);
                }
            }
        }
        return list;
    }

    /// <summary>
    /// Wraps a dictionary within a list.
    /// </summary>
    /// <param name="dictionary">The dictionary to wrap within a list.</param>
    /// <returns>A new list.</returns>
    internal static List<Dictionary<string, string>> WrapInList(this Dictionary<string, string> dictionary)
    {
        return new List<Dictionary<string, string>> { dictionary };
    }

    /// <summary>
    /// Converts a dictionary to a URI-encoded string.
    /// </summary>
    /// <param name="parameters">The parameters to encode.</param>
    /// <returns>A URI-encoded string.</returns>
    internal static string? ToQueryString(this IDictionary<string, object> parameters) =>
        !parameters.Any()
            ? null
            : string.Join("&", parameters.Where(x => x.Value != null)
                .Select(x => $"{WebUtility.UrlEncode(x.Key)}={WebUtility.UrlEncode(ValueToQueryString(x.Value))}"));

    /// <summary>
    /// Converts an object into its string representation. Lists will be returned as comma-delimited strings.
    /// </summary>
    /// <param name="value">The value to convert to string.</param>
    /// <returns>The formatted string.</returns>
    internal static string ValueToQueryString(object value)
    {
        if (value is IEnumerable enumValue and not string)
        {
            return JsonSerializer.Serialize(value, EngageBaySerializerOptions.Default);
            // return string.Join(",", (enumValue).Cast<object>());
        }
        return value.ToStringInvariant();
    }
}
