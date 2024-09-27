namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public abstract class EngageBaseWriteTests<TClass, TObject> : EngageBaseReadTests<TClass, TObject>
    where TClass : EngageBaseWrite<TObject>
    where TObject : ApiObject
{
    protected EngageBaseWriteTests(ITestOutputHelper output, long validId) : 
        base(output, validId)
    { }
    
    protected abstract TObject GetObjectCreate();
    protected abstract TObject GetObjectUpdate();

    // [Fact]
    // public async Task CreateAsync_Object_ReturnsData()
    // {
    //     using var c = CreateContext();
    //
    //     var result = await c.EngageBay.CreateAsync(CreateObject());
    //
    //     Assert.NotNull(result.Id);
    // }

    [Fact]
    public async Task Update_ValidId_ReturnsData()
    {
        using var c = CreateContext();

        var result = await c.EngageBay.UpdateAsync(ValidId, GetObjectUpdate());

        Assert.NotNull(result.Id);
    }
    
    [Fact]
    public async Task Update_InvalidId_ThrowsError()
    {
        using var c = CreateContext();

        var act = () => c.EngageBay.UpdateAsync(InvalidId, GetObjectUpdate());

        await Assert.ThrowsAsync<InvalidOperationException>(act);
    }
}
