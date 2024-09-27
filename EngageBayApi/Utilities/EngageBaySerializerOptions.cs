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
        result.Converters.Add(new JsonConverterStringEnum<ApiFieldType>(new UpperCaseNamingPolicy()));
        result.Converters.Add(new JsonConverterStringEnum<ApiPropertyType>(new UpperCaseNamingPolicy()));
        result.Converters.Add(new JsonConverterStringEnum<ApiTaskStatus>(new SnakeCaseNamingPolicy()));
        result.Converters.Add(new JsonConverterStringEnum<ApiTaskType>(new UpperCaseNamingPolicy()));
        return result;
    }
}
