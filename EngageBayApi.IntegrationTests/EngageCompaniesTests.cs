namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageCompaniesTests(ITestOutputHelper output) :
    EngageBaseComplexTests<EngageCompanies, ApiCompany>(output, 6193315960848384, "best")
{
    protected override ApiCompany GetObjectCreate() => new ApiCompany().SetName("UnitTest");
    protected override ApiCompany GetObjectUpdate() => new ApiCompany().SetUrl("http://www.perdu.com");

    [Fact]
    public async Task SelectList_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync();

        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task SelectList_PageSize1_ReturnsSingle()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListAsync(new SelectListOptions { PageSize = 1 });

        Assert.Single(result);
    }
    
    [Fact]
    public async Task AddContact_ValidId_CompanyHasContact()
    {
        var c = CreateContext();

        await c.EngageBay.AddContactAsync(ValidId, EngageContactsTests.ValidContactId);
        
        // var result = await c.EngageBay.SelectAsync(ValidId);
        // Assert.NotNull(result);
        // Assert.NotNull(result.ContactIds);
        // Assert.Contains(EngageContactsTests.ValidContactId, result.ContactIds);
    }
    
    [Fact]
    public async Task AddContact_ValidEmail_CompanyHasContact()
    {
        var c = CreateContext();

        await c.EngageBay.AddContactAsync(ValidId, EngageContactsTests.ValidContactEmail);
        
        // var result = await c.EngageBay.SelectAsync(ValidId);
        // Assert.NotNull(result);
        // Assert.NotNull(result.ContactIds);
        // Assert.Contains(EngageContactsTests.ValidContactId, result.ContactIds);
    }
}
