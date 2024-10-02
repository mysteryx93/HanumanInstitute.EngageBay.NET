using System.Text;
using Microsoft.Extensions.Logging;

namespace HanumanInstitute.EngageBayApi.IntegrationTests;

/// <summary>
/// Registers all logs into a StringBuilder that can be recovered with ToString.
/// </summary>
public class MockLogger<T> : ILogger<T>
{
    private readonly ITestOutputHelper _output;
    
    public MockLogger(ITestOutputHelper output)
    {
        _output = output;
    }

    public bool RecordRequests { get; set; } = true;
    public bool RecordResponses { get; set; } = true;

    public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();

    public bool IsEnabled(LogLevel logLevel) => logLevel == LogLevel.Trace ? RecordResponses : RecordRequests;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (logLevel == LogLevel.Information && RecordRequests)
        {
            _output.WriteLine(state.ToStringInvariant());
        }
        else if (logLevel == LogLevel.Trace && RecordResponses)
        {
            _output.WriteLine(state.ToStringInvariant());
            _output.WriteLine("");
        }
    }
}
