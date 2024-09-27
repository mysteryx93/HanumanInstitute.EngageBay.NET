namespace HanumanInstitute.EngageBayApi.Models;

public class ApiTask : ApiObject
{
    public int? OwnerId { get; set; }
    public string? EntityGroupName { get; set; }
    public bool? IsDue { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? NameSort { get; set; }
    public string? Type { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? ClosedDate { get; set; }
    public string? TaskMilestone { get; set; }
    public int? QueueId { get; set; }
    public ApiOwner? Owner { get; set; }
    public IList<int>? ContactIds { get; set; }
    public IList<int>? CompanyIds { get; set; }
    public IList<int>? DealIds { get; set; }
    public IList<int>? TaskIds { get; set; }
    public IList<int>? Subscribers { get; set; }
    public IList<int>? Deals { get; set; }
}
