namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Provides EngageBay API support for Form objects.
/// Forms are used to simply and easily gather information from your contacts. Our ONTRAforms are the recommended form type, as we offer 
/// many pre-designed and customizable templates which will greatly simplify your process. We also offer legacy SmartForms, which allow you to create your own designs.
/// </summary>
public class EngageForms : EngageBaseRead<ApiForm>, IEngageForms
{
    public EngageForms(EngageHttpClient apiRequest) :
        base(apiRequest, "dev/api/panel/forms")
    { }
}
