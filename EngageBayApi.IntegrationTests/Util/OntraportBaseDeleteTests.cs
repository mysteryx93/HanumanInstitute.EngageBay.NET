namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public abstract class EngageBaseDeleteTests<TClass, TObject> : EngageBaseWriteTests<TClass, TObject>
    where TClass : EngageBaseDelete<TObject>
    where TObject : ApiObject
{
    protected EngageBaseDeleteTests(ITestOutputHelper output, long validId) : 
        base(output, validId)
    {
    }

    [Fact]
    public async Task CreateAndDelete_IdJustCreated_ThrowsNoException()
    {
        var c = CreateContext();
        
        var obj = await c.EngageBay.CreateAsync(GetObjectCreate());
        var id = obj.Id!.Value;
        await c.EngageBay.DeleteAsync(id);

        Assert.Null(await c.EngageBay.SelectAsync(id));
    }
}
