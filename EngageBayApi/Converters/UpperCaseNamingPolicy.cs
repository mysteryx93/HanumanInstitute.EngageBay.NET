using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.Converters;

public class UpperCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToUpper();
}
