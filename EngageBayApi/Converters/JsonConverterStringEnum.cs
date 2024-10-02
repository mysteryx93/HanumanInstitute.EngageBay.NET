using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

/// <summary>
/// Converts a string field into an enumeration, using specified naming policy.
/// </summary>
/// <typeparam name="T">The enumeration type.</typeparam>
public class JsonConverterStringEnum<T> : JsonConverter<T>
{
    protected readonly JsonNamingPolicy _namingPolicy;

    public JsonConverterStringEnum(JsonNamingPolicy? namingPolicy = null)
    {
        _namingPolicy = namingPolicy ?? new SnakeCaseNamingPolicy();
    }
    
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value != null && _namingPolicy is SnakeCaseNamingPolicy)
        {
            value = value.Replace("_", "");
        }
        return value.Convert<T>();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        //var conv = value != null ? _namingPolicy.ConvertName(value.ToStringInvariant()) : null;
        writer.WriteStringValue(Format(value));
    }
    
    protected virtual string? Format(T value) => _namingPolicy.ConvertName(value.ToStringInvariant());
}
