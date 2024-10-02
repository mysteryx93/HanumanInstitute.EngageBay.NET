namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageBroadcastsTests
{
    protected ITestOutputHelper Output { get; }
    public const long ValidTemplateId = 4624700656582656;

    public EngageBroadcastsTests(ITestOutputHelper output)
    {
        Output = output;
    }
    
    protected EngageBayContext<EngageBroadcasts> CreateContext() => new(Output);

    [Fact]
    public async Task Broadcast_Emails_NoError()
    {
        var c = CreateContext();

        await c.EngageBay.BroadcastAsync(new[] { "mysteryx93@protonmail.com" }, ValidTemplateId, "mysteryx93@hotmail.com" );
    }
}
