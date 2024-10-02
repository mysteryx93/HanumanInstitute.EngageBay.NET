namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public abstract class EngageBaseComplexTests<TClass, TObject> : EngageBaseDeleteTests<TClass, TObject>
    where TClass : EngageBaseComplex<TObject>
    where TObject : ApiObjectComplex
{
    private readonly string _searchKeyword;
    
    public EngageBaseComplexTests(ITestOutputHelper output, long validId, string searchKeyword) :
        base(output, validId)
    {
        _searchKeyword = searchKeyword;
    }
    
    [Fact]
    public async Task Search_Keyword_ReturnsData()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SearchAsync(_searchKeyword);

        Assert.NotEmpty(result);
    }
}
