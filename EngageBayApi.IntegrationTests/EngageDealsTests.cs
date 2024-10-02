namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageDealsTests(ITestOutputHelper output) :
    EngageBaseComplexTests<EngageDeals, ApiDeal>(output, 5207756962529280, "best")
{
    protected override ApiDeal GetObjectCreate() => new ApiDeal { Name = "Unit Test", MilestoneLabelName = "New"};
    protected override ApiDeal GetObjectUpdate() => new ApiDeal { Name = "Updated"};
    private const long EnergyReadingTrack = 5796369815306240;
    
    [Fact]
    public async Task SelectMultiple_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync();

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task SelectMultiple_WithTrack_ReturnsForTrack()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync(EnergyReadingTrack);

        Assert.NotEmpty(result);
    }
}
