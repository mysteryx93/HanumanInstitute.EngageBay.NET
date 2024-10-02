namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageTagsTests
{
    protected ITestOutputHelper Output { get; }

    public EngageTagsTests(ITestOutputHelper output)
    {
        Output = output;
    }
    
    protected EngageBayContext<EngageTags> CreateContext() => new(Output);

    [Fact]
    public async Task SelectList_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync();

        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task Add_NewTag_ReturnsAll()
    {
        const string TagName = "NewTag";
        var c = CreateContext();

        await c.EngageBay.AddAsync(TagName);

        var result = await c.EngageBay.SelectListAsync();
        Assert.Contains(result, x => x.Tag == TagName);
    }
}
