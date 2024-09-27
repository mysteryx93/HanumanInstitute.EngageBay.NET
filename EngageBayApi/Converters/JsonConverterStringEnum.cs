using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

/// <summary>
/// Converts a string field into an enumeration, using SnakeCase naming strategy by default.
/// </summary>
/// <typeparam name="T">The enumeration type.</typeparam>
public class JsonConverterStringEnum<T> : JsonConverter<T?>
    where T : struct
{
    private readonly JsonNamingPolicy _namingPolicy;

    public JsonConverterStringEnum() : this(null)
    { }

    public JsonConverterStringEnum(JsonNamingPolicy? namingStrategy)
    {
        _namingPolicy = namingStrategy ?? new SnakeCaseNamingPolicy();
    }
    
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value != null && _namingPolicy is SnakeCaseNamingPolicy)
        {
            value = value.Replace("_", "");
        }
        return value.Convert<T?>();
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        var conv = value != null ? _namingPolicy.ConvertName(value.ToStringInvariant()) : null;
        writer.WriteStringValue(conv);
    }

    // public override string? NullString => null;
    //
    // public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    // {
    //     var value = reader.GetValue<string>();
    //     return Parse(value)!;
    // }
    //
    // [SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Reviewed: Replace overload with culture is not available in .NET Standard 2.0")]
    // public override T? Parse(string? value) =>
    //     !IsNullValue(value) ? value?.Replace("_", "")?.Convert<T?>() : (T?)null;
    //
    // public override string? Format(T? value) =>
    //     value != null ? _namingPolicy.ConvertName(value.ToStringInvariant()) : null;
}
