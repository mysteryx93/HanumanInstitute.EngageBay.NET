namespace HanumanInstitute.EngageBayApi.IntegrationTests;

public class EngageContactsTests(ITestOutputHelper output) : 
    EngageBaseComplexTests<EngageContacts, ApiContact>(output, ValidContactId, "Best")
{
    public const long ValidContactId = 5569229278674944;
    public const string ValidContactEmail = "best@email.ever";
    public const string ValidOwnerEmail = "etienne@hanumaninstitute.com";
    public const long ValidFormId = 6313033308831744;
    public const long ValidSequenceId = 6603373836238848;
    public const long ValidListId = 4794865247584256;
    public const long ValidProductId = 5889207748001792;
    public const string Tag1 = "Test Tag 1";
    public const string Tag2 = "Test Tag 2";
    
    protected override ApiContact GetObjectCreate() => new ApiContact().SetName("UnitTest").SetEmail("unit@test.com");
    protected override ApiContact GetObjectUpdate() => new ApiContact().SetName("Updated");
    
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
    public async Task Select_ValidEmail_ReturnsContact()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(ValidContactEmail);

        Assert.NotNull(result);
        Assert.Equal(ValidContactEmail, result.Email);
    }
    
    [Fact]
    public async Task Select_InvalidEmail_ReturnsNull()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectAsync(InvalidEmail);

        Assert.Null(result);
    }
    
    [Fact]
    public async Task AddTags_ByContactId_ContactHasTag()
    {
        var c = CreateContext();

        await c.EngageBay.AddTagsAsync(ValidContactId, new[] {Tag1, Tag2});
        
        var result = await c.EngageBay.ListTagsAsync(ValidId);
        Assert.NotNull(result);
        Assert.Contains(result, x => x.Tag == Tag1);
        Assert.Contains(result, x => x.Tag == Tag2);
    }
    
    [Fact]
    public async Task AddTags_ByContactEmail_ContactHasTag()
    {
        var c = CreateContext();

        await c.EngageBay.AddTagsAsync(ValidContactEmail, new[] {Tag1, Tag2});
        
        var result = await c.EngageBay.ListTagsAsync(ValidContactEmail);
        Assert.NotNull(result);
        Assert.Contains(result, x => x.Tag == Tag1);
        Assert.Contains(result, x => x.Tag == Tag2);
    }
    
    [Fact]
    public async Task DeleteTags_ByContactId_ContactHasTag()
    {
        var c = CreateContext();

        await c.EngageBay.DeleteTagsAsync(ValidContactId, new[] {Tag1, Tag2});
        
        var result = await c.EngageBay.ListTagsAsync(ValidId);
        Assert.NotNull(result);
        Assert.DoesNotContain(result, x => x.Tag == Tag1);
        Assert.DoesNotContain(result, x => x.Tag == Tag2);
    }
    
    [Fact]
    public async Task DeleteTags_ByContactEmail_ContactHasTag()
    {
        var c = CreateContext();

        await c.EngageBay.DeleteTagsAsync(ValidContactEmail, new[] {Tag1, Tag2});
        
        var result = await c.EngageBay.ListTagsAsync(ValidContactEmail);
        Assert.NotNull(result);
        Assert.NotNull(result);
        Assert.DoesNotContain(result, x => x.Tag == Tag1);
        Assert.DoesNotContain(result, x => x.Tag == Tag2);
    }
    
    [Fact]
    public async Task AddScore_ValidEmail_ContactHasScore()
    {
        var c = CreateContext();

        await c.EngageBay.AddScoreAsync(ValidContactEmail, 10);
        
        var result = await c.EngageBay.SelectAsync(ValidContactEmail);
        Assert.NotNull(result);
        Assert.Equal(10, result.Score);
    }
    
    [Fact]
    public async Task ChangeOwner_ValidEmail_ContactHasOwner()
    {
        var c = CreateContext();

        await c.EngageBay.ChangeOwnerAsync(ValidContactId, ValidOwnerEmail);
        
        var result = await c.EngageBay.SelectAsync(ValidContactId);
        Assert.NotNull(result);
        Assert.Equal(ValidOwnerEmail, result.Owner?.Email);
    }
    
    [Fact]
    public async Task ChangeOwner_InvalidEmail_ThrowError()
    {
        var c = CreateContext();

        var act = () => c.EngageBay.ChangeOwnerAsync(ValidContactId, InvalidEmail);
        
        await Assert.ThrowsAsync<InvalidOperationException>(act);
    }
    
    [Fact]
    public async Task BatchCreate_NewContacts_NewContactsCreated()
    {
        const string Batch1 = "batch1@test.com";
        const string Batch2 = "batch2@test.com";
        var c = CreateContext();
        var contact1 = await c.EngageBay.SelectAsync(Batch1);
        var contact2 = await c.EngageBay.SelectAsync(Batch2);
        if (contact1 != null)
        {
            await c.EngageBay.DeleteAsync(contact1.Id!.Value);
        }
        if (contact2 != null)
        {
            await c.EngageBay.DeleteAsync(contact2.Id!.Value);
        }

        var newContacts = new[]
        {
            new ApiContact().SetName("Batch1").SetEmail("batch1@test.com"),
            new ApiContact().SetName("Batch2").SetEmail("batch2@test.com")
        };
        var result = await c.EngageBay.BatchCreateAsync(newContacts);
        
        Assert.Equal("success", result.Status);
    }
    
    [Fact]
    public async Task SelectNotes_ValidId_ReturnNotes()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectNotesAsync(ValidContactId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task SelectNotes_InvalidId_ReturnEmptyList()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectNotesAsync(InvalidId);

        Assert.NotNull(result);
        Assert.Empty(result);
    }
    
    [Fact]
    public async Task SelectCallLogs_ValidId_ReturnLogs()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectCallLogsAsync(ValidContactId);

        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task SelectCallLogs_InvalidId_ReturnEmptyList()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectCallLogsAsync(InvalidId);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task AddToForm_ValidId_NoError()
    {
        var c = CreateContext();

        await c.EngageBay.AddToFormAsync(ValidContactEmail, ValidFormId);
        
    }
    
    [Fact]
    public async Task AddToSequence_ValidId_NoError()
    {
        var c = CreateContext();

        await c.EngageBay.AddToSequenceAsync(ValidContactEmail, ValidSequenceId);
    }
    
    [Fact]
    public async Task AddToList_ValidId_NoError()
    {
        var c = CreateContext();

        await c.EngageBay.AddToListAsync(ValidContactEmail, ValidListId);
    }
    
    [Fact]
    public async Task SelectListOfLists_NoArgs_ReturnsAll()
    {
        var c = CreateContext();

        var result = await c.EngageBay.SelectListOfListsAsync();

        Assert.NotEmpty(result);
    }
    
    [Fact]
    public async Task AddAndRemoveProduct_Valid_NoError()
    {
        var c = CreateContext();

        await c.EngageBay.AddProductAsync(ValidId, ValidProductId);
        await c.EngageBay.RemoveProductAsync(ValidId, ValidProductId);
    }
}
