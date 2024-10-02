namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageUsersTests
{
    protected ITestOutputHelper Output { get; }

    public EngageUsersTests(ITestOutputHelper output)
    {
        Output = output;
    }
    
    protected EngageBayContext<EngageUsers> CreateContext() => new(Output);

    [Fact]
    public async Task SelectOwnersList_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectOwnersListAsync();

        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task SelectProfile_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectProfileAsync();

        Assert.NotNull(result);
    }
}
