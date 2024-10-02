namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageTracksTests(ITestOutputHelper output) :
    EngageBaseDeleteTests<EngageTracks, ApiTrack>(output, 4886071730241536)
{
    protected override ApiTrack GetObjectCreate() => new ApiTrack { Name = "Unit Test", Milestones = new List<ApiMilestone> { new() {LabelName = "M1"}}};
    protected override ApiTrack GetObjectUpdate() => new ApiTrack { Name = "Updated", Milestones = new List<ApiMilestone> { new() {LabelName = "M1"}}, CreatedTime = DateTime.Now};
    
    [Fact]
    public async Task SelectMultiple_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync();

        Assert.NotEmpty(result);
    }
}
