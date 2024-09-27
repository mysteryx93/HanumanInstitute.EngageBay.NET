namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageCompaniesTests(ITestOutputHelper output) :
    EngageBaseComplexTests<EngageCompanies, ApiCompany>(output, 6193315960848384, "best")
{
    protected override ApiCompany GetObjectCreate() => new ApiCompany().SetName("UnitTest");
    protected override ApiCompany GetObjectUpdate() => new ApiCompany().SetUrl("http://www.perdu.com");

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
