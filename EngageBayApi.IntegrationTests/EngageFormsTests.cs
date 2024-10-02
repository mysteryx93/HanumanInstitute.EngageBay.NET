namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageFormsTests
{
    protected ITestOutputHelper Output { get; }

    public EngageFormsTests(ITestOutputHelper output)
    {
        Output = output;
    }
    
    protected EngageBayContext<EngageForms> CreateContext() => new(Output);

    [Fact]
    public async Task SelectList_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync();

        Assert.NotEmpty(result);
    }
}
