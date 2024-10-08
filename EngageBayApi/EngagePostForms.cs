﻿using System.Net;
using System.Net.Http;
using System.Text;

namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Sends data to EngageBay by posting a SmartForm which can then perform additional actions. 
/// This can be used as an alternative to the API. The form post can be done from the client's browser or from the server.
/// </summary>
public class EngagePostForms : IEngagePostForms
{
    private const string FormPosttUrl = "https://forms.EngageBay.com/v2.4/form_processor.php?";
    private readonly HttpClient _httpClient;

    public EngagePostForms(HttpClient httpClient)
    {
        _httpClient = Check.NotNull(httpClient);
        _httpClient.BaseAddress = new Uri(FormPosttUrl);
    }

    /// <summary>
    /// Posts an EngageBay form with specified data from the server. This method does not lock the thread.
    /// </summary>
    /// <param name="formId">The EngageBay UID of the form.</param>
    /// <param name="formParams">The list of form data to send.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "Reviewed: can't pass null Uri or it can't recognize form string.")]
    public async Task ServerPostAsync(string formId, IDictionary<string, object?> formParams, CancellationToken cancellationToken = default)
    {
        formParams.Add("uid", formId);
        var formString = formParams.Select(x => new KeyValuePair<string, string>(x.Key, x.Value?.ToStringInvariant() ?? string.Empty));
        using var content = new FormUrlEncodedContent(formString);
        await _httpClient.PostAsync(string.Empty, content, cancellationToken);
    }
}
