using Microsoft.Extensions.Logging;

namespace HanumanInstitute.EngageBayApi.IntegrationTests;

/// <summary>
/// Initializes necessary classes to test EngageBay API classes.
/// </summary>
/// <typeparam name="T">The type of EngageBay API class to test.</typeparam>
public class EngageBayContext<T>
    where T : class
{
    private readonly ITestOutputHelper _output;

    public EngageBayContext(ITestOutputHelper output = null)
    {
        _output = output;
    }

    public ILogger<EngageHttpClient> Log => _log ??= new MockLogger<EngageHttpClient>(_output);
    private ILogger<EngageHttpClient> _log;

    public EngageHttpClient HttpClient => _httpClient ??= ConfigHelper.GetHttpClient(Log);
    private EngageHttpClient _httpClient;

    public T EngageBay => _engageBay ??= (T)Activator.CreateInstance(typeof(T), HttpClient)!;
    private T _engageBay;
}
