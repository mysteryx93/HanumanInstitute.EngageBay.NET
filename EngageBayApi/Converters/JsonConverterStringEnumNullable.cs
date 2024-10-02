using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

/// <summary>
/// Converts a string field into an enumeration, using SnakeCase naming strategy by default.
/// </summary>
/// <typeparam name="T">The enumeration type.</typeparam>
public class JsonConverterStringEnumNullable<T> : JsonConverterStringEnum<T?>
    where T : struct
{
    public JsonConverterStringEnumNullable(JsonNamingPolicy? namingPolicy = null) : base(namingPolicy)
    { }

    protected override string? Format(T? value) => value != null ? _namingPolicy.ConvertName(value.ToStringInvariant()) : null;
}
