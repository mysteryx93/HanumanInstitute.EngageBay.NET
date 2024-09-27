using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HanumanInstitute.EngageBayApi.IntegrationTests;

[SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Reviewed: Can't call AddUserSecrets if class is static")]
[SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Reviewed: HttpClient needs to be disposed by EngageBayPostForms or by the IOC container.")]
public class ConfigHelper
{
    public static EngageHttpClient GetHttpClient(ILogger<EngageHttpClient> logger = null)
    {
        // var factory = Mock.Of<IHttpClientFactory>(x => x.CreateClient(It.IsAny<string>()) == new HttpClient());
        return new EngageHttpClient(new HttpClient(), GetConfig(), logger);
    }

    public static IOptions<EngageBayConfig> GetConfig()
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<ConfigHelper>();
        var configuration = builder.Build();

        var authKey = configuration["EngageBayAuthorization"];

        if (string.IsNullOrEmpty(authKey))
        {
            throw new ArgumentException(
                """
                EngageBay API credentials must be set in your User Secret Manager. Open the command-line tool and navigate to the EngageBayApi.IntegrationTests project directory.

                Use the following commands to set your keys.
                dotnet user-secrets set EngageBayAuthorization "your-key-here"
                """);
        }

        var config = new EngageBayConfig()
        {
            Authorization = authKey
        };
        return Mock.Of<IOptions<EngageBayConfig>>(x => x.Value == config);
    }
}
