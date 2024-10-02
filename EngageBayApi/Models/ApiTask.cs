namespace HanumanInstitute.EngageBayApi.Models;

public class ApiTask : ApiObject
{
    public long? OwnerId { get; set; }
    public string? EntityGroupName { get; set; }
    public bool? IsDue { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? NameSort { get; set; }
    public ApiTaskType? Type { get; set; }
    public DateTime? CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? ClosedDate { get; set; }
    public ApiTaskStatus? TaskMilestone { get; set; }
    public long? QueueId { get; set; }
    public ApiOwner? Owner { get; set; }
    public IList<long>? ContactIds { get; set; }
    public IList<long>? CompanyIds { get; set; }
    public IList<long>? DealIds { get; set; }
    public IList<long>? TaskIds { get; set; }
    public IList<ApiContact>? Subscribers { get; set; }
    public IList<ApiDeal>? Deals { get; set; }
}
