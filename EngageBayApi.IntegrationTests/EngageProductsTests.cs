namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageProductsTests(ITestOutputHelper output) :
    EngageBaseComplexTests<EngageProducts, ApiProduct>(output, 5889207748001792, "Test")
{
    protected override ApiProduct GetObjectCreate() => new ApiProduct {Name = "Create Test"};
    protected override ApiProduct GetObjectUpdate() => new ApiProduct {Name = "Update Test"};
    private const string ValidProductName = "Best Product";

    [Fact]
    public async Task Select_ByName_ReturnsProduct()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(ValidProductName);

        Assert.NotNull(result);
        Assert.Equal(ValidProductName, result.Name);
    }
    
    [Fact]
    public async Task SelectList_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync(new SelectListOptions(5));

        Assert.NotEmpty(result);
    }
}
