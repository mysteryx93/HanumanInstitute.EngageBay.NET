using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using HanumanInstitute.EngageBayApi.Properties;

namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides extension methods to parse JSON data.
/// </summary>
public static class JsonElementExtensions
{
    // /// <summary>
    // /// Parses JSON as a single object.
    // /// </summary>
    // /// <param name="json">The JSON data to parse.</param>
    // /// <typeparam name="T">The data type of parse into.</typeparam>
    // /// <returns>An object of type T.</returns>
    // /// <exception cref="InvalidOperationException">Response data could not be parsed.</exception>
    // private static T Parse<T>(this JsonElement json) => 
    //     ParseOrThrow<T>(json);
    //
    // /// <summary>
    // /// Parses JSON as a single object.
    // /// </summary>
    // /// <param name="json">The JSON data to parse.</param>
    // /// <typeparam name="T">The data type of parse into.</typeparam>
    // /// <returns>An object of type T.</returns>
    // /// <exception cref="InvalidOperationException">Response data could not be parsed.</exception>
    // private static T? Parse<T>(this JsonElement? json) => 
    //     json.HasValue ? ParseOrThrow<T>(json!.Value) : default;
    //
    // /// <summary>
    // /// Parses JSON as a list of objects.
    // /// </summary>
    // /// <param name="json">The JSON data to parse.</param>
    // /// <typeparam name="T">The data type of parse into.</typeparam>
    // /// <returns>A list of objects of type T.</returns>
    // /// <exception cref="InvalidOperationException">Response data could not be parsed.</exception>
    // private static IList<T> ParseList<T>(this JsonElement json) =>
    //     json.EnumerateArray().Select(x => x.ParseOrThrow<T>()).ToList();
    //
    // /// <summary>
    // /// Parses JSON as a list of objects.
    // /// </summary>
    // /// <param name="json">The JSON data to parse.</param>
    // /// <typeparam name="T">The data type of parse into.</typeparam>
    // /// <returns>A list of objects of type T.</returns>
    // /// <exception cref="InvalidOperationException">Response data could not be parsed.</exception>
    // private static IList<T> ParseList<T>(this JsonElement? json) =>
    //     json.HasValue ? json!.Value.EnumerateArray().Select(x => x.ParseOrThrow<T>()).ToList() : [];
    //
    // /// <summary>
    // /// Creates an instance of the ApiObject of type T and parses data into it.
    // /// </summary>
    // /// <param name="json">The JSON data to parse.</param>
    // /// <typeparam name="T">The data type of parse into.</typeparam>
    // /// <returns>A new object of type T.</returns>
    // /// <exception cref="InvalidOperationException">Response data could not be parsed.</exception>
    // private static T ParseOrThrow<T>(this JsonElement json)
    // {
    //     try
    //     {
    //         return json.ToObject<T>();
    //     }
    //     catch (JsonException ex)
    //     {
    //         throw new InvalidOperationException(Resources.ResponseInvalidJson, ex);
    //     }
    // }
    
    /// <summary>
    /// Deserializes a JsonElement as an object, which is not supported in .NET 3.1.
    /// </summary>
    /// <exception cref="JsonException">The JSON data could not be parsed.</exception>
    public static T ToObject<T>(this JsonElement element, JsonSerializerOptions? options = null)
    {
        var bufferWriter = new ArrayBufferWriter<byte>();
        using (var writer = new Utf8JsonWriter(bufferWriter))
        {
            element.WriteTo(writer);
        }

        try
        {
            return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options ?? EngageBaySerializerOptions.Default)!;
        }
        catch (JsonException ex)
        {
            // Throw an error message that is more useful for debugging.
            var msg = "Could not deserialize JSON into object {0}.\n{1}".FormatInvariant(typeof(T).Name, element.GetRawText());
            throw new JsonException(msg, ex);
        }
    }

    public static T? GetValue<T>(this ref Utf8JsonReader reader)
    {
        var value = reader.TokenType switch
        {
            JsonTokenType.String => ReadString<T>(ref reader),
            JsonTokenType.False => false,
            JsonTokenType.True => true,
            JsonTokenType.Null => null,
            JsonTokenType.Number => ReadNumber<T>(ref reader),
            _ => throw new JsonException()
        };
        if (typeof(T) == typeof(string) && value?.GetType() != typeof(string))
        {
            // False cannot be converted to String without this.
            return (T?)(object?)value?.ToStringInvariant();
        }
        return (T?)value!;
    }

    private static object? ReadNumber<T>(ref Utf8JsonReader reader)
    {
        var t = typeof(T);
        if (t == typeof(bool) || t == typeof(bool?))
        {
            return reader.GetInt16() == 1;
        }
        else if (t == typeof(short) || t == typeof(short?))
        {
            return reader.GetInt16();
        }
        else if (t == typeof(int) || t == typeof(int?))
        {
            return reader.GetInt32();
        }
        else if (t == typeof(long) || t == typeof(long?))
        {
            return reader.GetInt64();
        }
        else if (t == typeof(float) || t == typeof(float?))
        {
            return reader.GetSingle();
        }
        else if (t == typeof(double) || t == typeof(double?))
        {
            return reader.GetDouble();
        }
        else if (t == typeof(decimal) || t == typeof(decimal?))
        {
            return reader.GetDecimal();
        }
        else if (t == typeof(string))
        {
            return reader.GetDecimal().ToStringInvariant();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private static object? ReadString<T>(ref Utf8JsonReader reader)
    {
        var t = typeof(T);
        if (t == typeof(string))
        {
            return reader.GetString();
        }
        if (t == typeof(bool) || t == typeof(bool?))
        {
            var val = reader.GetString();
            return val == "1" || val == "true" || val == "True";
        }
        return reader.GetString().Convert(t);
    }
}
