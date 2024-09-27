using Microsoft.Extensions.Logging;

namespace HanumanInstitute.EngageBayApi.IntegrationTests;

/// <summary>
/// Initializes necessary classes to test EngageBay API classes.
/// </summary>
/// <typeparam name="T">The type of EngageBay API class to test.</typeparam>
public class EngageBayContext<T> : IDisposable
    where T : class
{
    private readonly ITestOutputHelper _output;

    public EngageBayContext(ITestOutputHelper output = null)
    {
        if (output != null)
        {
            _output = output;
            AppDomain.CurrentDomain.UnhandledException += (_, _) => Dispose(true);
        }
    }

    public ILogger<EngageHttpClient> Log => _log ??= new MockLogger<EngageHttpClient>();
    private ILogger<EngageHttpClient> _log;

    public EngageHttpClient HttpClient => _httpClient ??= ConfigHelper.GetHttpClient(Log);
    private EngageHttpClient _httpClient;

    public T EngageBay => _engageBay ??= (T)Activator.CreateInstance(typeof(T), HttpClient)!;
    private T _engageBay;

    private bool _disposedValue;
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue) { return; }
        if (disposing)
        {
            _output?.WriteLine(Log.ToString());
        }
        _disposedValue = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
