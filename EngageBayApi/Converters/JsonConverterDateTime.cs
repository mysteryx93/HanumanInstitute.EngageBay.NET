using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

/// <summary>
/// Converts a Unix Epoch seconds field into a DateTimeOffset property.
/// </summary>
public class JsonConverterDateTime : JsonConverter<DateTime?>
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
    
    //
    // public override string NullString => "0";
    //
    // public override DateTimeOffset? Parse(long? value)
    // {
    //     if (value.HasValue)
    //     {
    //         // var valueLong = value!.Convert<long>();
    //         return Milliseconds ?
    //             DateTimeOffset.FromUnixTimeMilliseconds(value.Value) :
    //             DateTimeOffset.FromUnixTimeSeconds(value.Value);
    //     }
    //     return null;
    // }
    //
    // public long Format(DateTime? value) => 
    //     value != null ? new DateTimeOffset(value.Value).ToUnixTimeSeconds() : 0;
}
