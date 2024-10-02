namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public abstract class EngageBaseReadTests<TClass, TObject>
    where TClass : EngageBaseRead<TObject>
    where TObject : ApiObject
{
    protected ITestOutputHelper Output { get; }
    protected long ValidId { get; }
    protected long InvalidId { get; } = 99999;
    protected string InvalidEmail { get; } = "Invalid";

    protected EngageBaseReadTests(ITestOutputHelper output, long validId)
    {
        Output = output;
        ValidId = validId;
    }

    /// <summary>
    /// Creates a context that initializes all classes required for EngageBay API tests
    /// </summary>
    protected EngageBayContext<TClass> CreateContext() => new(Output);
    
    [Fact]
    public async Task Select_InvalidId_ReturnsNull()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(InvalidId);

        Assert.Null(result);
    }
    
    [Fact]
    public async Task Select_ValidId_ReturnsData()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(ValidId);

        Assert.NotNull(result);
    }
}
