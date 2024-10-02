using System.Text.Json;

namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageTasksTests(ITestOutputHelper output) :
    EngageBaseDeleteTests<EngageTasks, ApiTask>(output, 5646394322059264)
{
    protected override ApiTask GetObjectCreate() => new ApiTask { Name = "Unit Test" };
    protected override ApiTask GetObjectUpdate() => new ApiTask { Name = "Updated"};
    
    [Fact]
    public async Task SelectList_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync(options: new SelectListOptions(5));

        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task SelectList_ByTaskType_ReturnsTasksOfType()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync(ApiTaskType.Todo, options: new SelectListOptions(5));

        Assert.NotEmpty(result);
        Assert.DoesNotContain(result, x => x.Type != ApiTaskType.Todo);
    }

    [Fact]
    public async Task SelectList_ByTaskStatus_ReturnsTasksWithStatus()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync(null, ApiTaskStatus.NotStarted, options: new SelectListOptions(5));

        Assert.NotEmpty(result);
        Assert.DoesNotContain(result, x => x.TaskMilestone != ApiTaskStatus.NotStarted);
    }
}
