namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageContactsTests(ITestOutputHelper output) : 
    EngageBaseComplexTests<EngageContacts, ApiContact>(output, ValidContactId, "Best")
{
    public const long ValidContactId = 5569229278674944;
    public const string ValidContactEmail = "best@email.ever";
    
    protected override ApiContact GetObjectCreate() => new ApiContact().SetName("UnitTest").SetEmail("unit@test.com");
    protected override ApiContact GetObjectUpdate() => new ApiContact().SetName("Updated");
}
