using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

/// <summary>
/// Converts a Unix Epoch seconds field into a DateTimeOffset property.
/// </summary>
public class JsonConverterDateTime : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetValue<long?>();
        return value.HasValue ? DateTimeOffset.FromUnixTimeSeconds(value.Value).UtcDateTime : default;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var conv = new DateTimeOffset(value).ToUnixTimeSeconds();
        writer.WriteNumberValue(conv);
    }
}
