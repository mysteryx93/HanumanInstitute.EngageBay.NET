using System.Text.Json;

namespace HanumanInstitute.EngageBayApi;

public static class EngageBaySerializerOptions
{
    /// <summary>
    /// Returns the default settings to serialize and deserialize EngageBay Json data.
    /// </summary>
    public static JsonSerializerOptions Default => s_default ??= SetupDefault();
    private static JsonSerializerOptions? s_default;
    private static JsonSerializerOptions SetupDefault()
    {
        var result = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        result.Converters.Add(new JsonConverterDateTime());
        result.Converters.Add(new JsonConverterDateTimeNullable());
        result.Converters.AddEnum<ApiFieldType>(new UpperCaseNamingPolicy());
        result.Converters.AddEnum<ApiPropertyType>(new UpperCaseNamingPolicy());
        result.Converters.AddEnum<ApiTaskStatus>(new SnakeCaseNamingPolicy());
        result.Converters.AddEnum<ApiTaskType>(new UpperCaseNamingPolicy());
        return result;
    }

    private static void AddEnum<T>(this IList<JsonConverter> converters, JsonNamingPolicy namingPolicy)
        where T : struct
    {
        converters.Add(new JsonConverterStringEnum<T>(namingPolicy));
        converters.Add(new JsonConverterStringEnumNullable<T>(namingPolicy));
    }
}
