namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public abstract class EngageBaseReadTests<TClass, TObject>
    where TClass : EngageBaseRead<TObject>
    where TObject : ApiObject
{
    protected ITestOutputHelper Output { get; }
    protected long ValidId { get; }
    protected long InvalidId { get; } = 99999;

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
        using var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(InvalidId);

        Assert.Null(result);
    }
    
    [Fact]
    public async Task Select_ValidId_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(ValidId);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task SelectMultiple_NoArgs_ReturnsAll()
    {
        using var c = CreateContext();

        var result = await c.EngageBay.SelectManyAsync();

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task SelectMultiple_PageSize1_ReturnsSingle()
    {
        using var c = CreateContext();

        var result = await c.EngageBay.SelectManyAsync(new SelectManyOptions { PageSize = 1 });

        Assert.Single(result);
    }
}
