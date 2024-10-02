namespace HanumanInstitute.EngageBayApi.Models;

public class ApiProduct : ApiObjectComplex
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public long? OwnerId { get; set; }
    public decimal? Price { get; set; }
    public string? DiscountType { get; set; }
    public decimal? Discount { get; set; }
    public string? Currency { get; set; }
}
