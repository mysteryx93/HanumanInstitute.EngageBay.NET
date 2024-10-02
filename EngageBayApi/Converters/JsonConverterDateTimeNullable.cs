using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

/// <summary>
/// Converts a Unix Epoch seconds field into a DateTimeOffset property.
/// </summary>
public class JsonConverterDateTimeNullable : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetValue<long?>();
        return value.HasValue ? DateTimeOffset.FromUnixTimeSeconds(value.Value).UtcDateTime : null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        var conv = value != null ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : 0;
        writer.WriteNumberValue(conv);
    }
}
