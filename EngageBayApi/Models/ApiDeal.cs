using T = HanumanInstitute.EngageBayApi.Models.ApiCompany;

namespace HanumanInstitute.EngageBayApi.Models;

public class ApiDeal : ApiObjectComplex
{
    public string? Name { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? ClosedDate { get; set; }
    public long? TrackId { get; set; }
    [JsonPropertyName("milestoneLabelName")]
    public string? MilestoneLabelName { get; set; }
    public IList<ApiTag>? Tags { get; set; }
    public double? Probability { get; set; }
    public ApiOwner? Owner { get; set; }
}
