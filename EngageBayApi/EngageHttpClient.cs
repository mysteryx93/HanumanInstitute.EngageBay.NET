using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Res = HanumanInstitute.EngageBayApi.Properties.Resources;

namespace HanumanInstitute.EngageBayApi;

/// <summary>
/// Sends API requests to EngageBay, formatting the parameters and parsing the response.
/// </summary>
public class EngageHttpClient
{
    private const string ContentJson = "application/json";
    private const string ContentUrl = "application/x-www-form-urlencoded";
    private readonly HttpClient _httpClient;
    private readonly ILogger<EngageHttpClient>? _logger;

    public EngageHttpClient(HttpClient httpClient, IOptions<EngageBayConfig> config, ILogger<EngageHttpClient>? logger)
    {
        _httpClient = httpClient.CheckNotNull();
        _logger = logger;

        var conf = config.CheckNotNull().Value;
        conf.Authorization.CheckNotNull();

        if (string.IsNullOrEmpty(conf.Authorization))
        {
            throw new ArgumentException(Res.ConfigAuthorizationRequired);
        }

        _httpClient.BaseAddress = new Uri("https://app.engagebay.com/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", conf.Authorization);
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    /// <summary>
    /// Sends a GET API query to EngageBay.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task GetAsync(string endpoint, object? values = null, bool returnNotFoundAsNull = true, CancellationToken cancellationToken = default) =>
        RequestAsync(endpoint, HttpMethod.Get, false, values, returnNotFoundAsNull, cancellationToken);
    
    /// <summary>
    /// Sends a GET API query to EngageBay and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<T?> GetAsync<T>(string endpoint, object? values = null, bool returnNotFoundAsNull = true, CancellationToken cancellationToken = default)
        where T : class =>
        await RequestAsync<T>(endpoint, HttpMethod.Get, false, values, returnNotFoundAsNull, cancellationToken);

    /// <summary>
    /// Sends a GET API query to EngageBay and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task<JsonElement?> GetJsonAsync(string endpoint, object? values = null, bool returnNotFoundAsNull = true, CancellationToken cancellationToken = default) =>
        RequestJsonAsync(endpoint, HttpMethod.Get, false, values, returnNotFoundAsNull, cancellationToken);

    /// <summary>
    /// Sends a DELETE API query to EngageBay.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task DeleteAsync(string endpoint, object? values = null, bool encodeJson = true, CancellationToken cancellationToken = default) =>
        RequestAsync(endpoint, HttpMethod.Delete, encodeJson, values, false, cancellationToken);
    
    /// <summary>
    /// Sends a DELETE API query to EngageBay and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task<T> DeleteAsync<T>(string endpoint, object? values = null, bool encodeJson = true, CancellationToken cancellationToken = default)
        where T : class =>
        RequestAsync<T>(endpoint, HttpMethod.Delete, encodeJson, values, false, cancellationToken)!;

    /// <summary>
    /// Sends a DELETE API query to EngageBay and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement> DeleteJsonAsync(string endpoint, object? values = null, bool encodeJson = true, CancellationToken cancellationToken = default) =>
        (await RequestJsonAsync(endpoint, HttpMethod.Delete, encodeJson, values, false, cancellationToken))!.Value;

    /// <summary>
    /// Sends a POST API query to EngageBay.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task PostAsync(string endpoint, object? values = null, bool encodeJson = true, CancellationToken cancellationToken = default) =>
        RequestAsync(endpoint, HttpMethod.Post, encodeJson, values, false, cancellationToken);
    
    /// <summary>
    /// Sends a POST API query to EngageBay and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task<T> PostAsync<T>(string endpoint, object? values = null, bool encodeJson = true, CancellationToken cancellationToken = default)
        where T : class =>
        RequestAsync<T>(endpoint, HttpMethod.Post, encodeJson, values, false, cancellationToken)!;

    /// <summary>
    /// Sends a POST API query to EngageBay and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as query data.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement> PostJsonAsync(string endpoint, object? values = null, bool encodeJson = true, CancellationToken cancellationToken = default) =>
        (await RequestJsonAsync(endpoint, HttpMethod.Post, encodeJson, values, false, cancellationToken))!.Value;

    /// <summary>
    /// Sends a PUT API query to EngageBay and deserializes the response as an object.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task PutAsync(string endpoint, object? values = null, CancellationToken cancellationToken = default) =>
        RequestAsync(endpoint, HttpMethod.Put, true, values, false, cancellationToken);
    
    /// <summary>
    /// Sends a PUT API query to EngageBay and deserializes the response as an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public Task<T> PutAsync<T>(string endpoint, object? values = null, CancellationToken cancellationToken = default)
        where T : class =>
        RequestAsync<T>(endpoint, HttpMethod.Put, true, values, false, cancellationToken)!;

    /// <summary>
    /// Sends a PUT API query to EngageBay and returns the response as a JsonElement for custom parsing.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    public async Task<JsonElement> PutJsonAsync(string endpoint, object? values = null, CancellationToken cancellationToken = default) =>
        (await RequestJsonAsync(endpoint, HttpMethod.Put, true, values, false, cancellationToken))!.Value;

    /// <summary>
    /// Sends an API query to EngageBay.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="method">The web request method.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    protected async Task RequestAsync(string endpoint, HttpMethod method, bool encodeJson, object? values = null,
        bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
    {
        using var response = await SendRequestAsync(endpoint, method, encodeJson, values, returnNotFoundAsNull, cancellationToken);
        if (response == null) { return; }
        using var responseStream = await response.Content.ReadAsStreamAsync();

        // Log response.
        if (_logger?.IsEnabled(LogLevel.Trace) == true)
        {
            using var logReader = new StreamReader(responseStream, Encoding.UTF8, true, 512, true);
            var logMsg = await logReader.ReadToEndAsync();
            _logger?.LogInformation(logMsg);
            responseStream.Seek(0, SeekOrigin.Begin);
        }
        
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Sends an API query to EngageBay and deserializes the result into an object.
    /// </summary>
    /// <typeparam name="T">The expected response data type. Set to JsonElement to parse manually. Set to Object to discard output.</typeparam>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="method">The web request method.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    protected async Task<T?> RequestAsync<T>(string endpoint, HttpMethod method, bool encodeJson, object? values = null, bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
        where T : class
    {
        using var response = await SendRequestAsync(endpoint, method, encodeJson, values, returnNotFoundAsNull, cancellationToken);
        if (response == null)
        {
            return null;
        }
        using var responseStream = await response.Content.ReadAsStreamAsync();

        // Log response.
        if (_logger?.IsEnabled(LogLevel.Trace) == true)
        {
            using var logReader = new StreamReader(responseStream, Encoding.UTF8, true, 512, true);
            var logMsg = await logReader.ReadToEndAsync();
            _logger?.LogInformation(logMsg);
            responseStream.Seek(0, SeekOrigin.Begin);
        }

        if (typeof(T) == typeof(object))
        {
            return null;
        }
        // Parse response.
        try
        {
            return await JsonSerializer.DeserializeAsync<T>(responseStream, EngageBaySerializerOptions.Default, CancellationToken.None);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(Res.ResponseInvalidJson, ex);
        }
    }

    /// <summary>
    /// Sends an API query to EngageBay and returns a JsonElement.
    /// </summary>
    /// <param name="endpoint">The URL endpoint, excluding that goes after https://app.engagebay.com/ </param>
    /// <param name="method">The web request method.</param>
    /// <param name="encodeJson">True to encode the request as Json, false to encode as URL query.</param>
    /// <param name="values">Values set by the method type.</param>
    /// <param name="returnNotFoundAsNull">If true, response code 404 will be returned as null instead of an exception.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An ApiResponse of the expected type.</returns>
    /// <exception cref="InvalidOperationException">There was an error while sending or parsing the request.</exception>
    /// <exception cref="HttpRequestException">There was an HTTP communication error or EngageBay returned an error.</exception>
    /// <exception cref="TaskCanceledException">The request timed-out or the user canceled the request's Task.</exception>
    [SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "Reviewed: It is safe to let the GC dispose the MemoryStream.")]
    protected async Task<JsonElement?> RequestJsonAsync(string endpoint, HttpMethod method, bool encodeJson, object? values = null, bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
    {
        using var response = await SendRequestAsync(endpoint, method, encodeJson, values, returnNotFoundAsNull, cancellationToken);
        if (response == null)
        {
            return null;
        }

        // Create a copy of the stream that we have control over.
        using var responseStream = await response.Content.ReadAsStreamAsync();
        var responseCopy = new MemoryStream();
        await responseStream.CopyToAsync(responseCopy);
        responseCopy.Seek(0, SeekOrigin.Begin);

        // Log response.
        if (_logger?.IsEnabled(LogLevel.Trace) == true)
        {
            var logMsg = Encoding.UTF8.GetString(responseCopy.GetBuffer());
            _logger?.LogInformation(logMsg);
        }

        try
        {
            var doc = await JsonDocument.ParseAsync(responseCopy, new JsonDocumentOptions(), CancellationToken.None);
            return doc.RootElement;
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(Res.ResponseInvalidJson, ex);
        }
    }

    /// <summary>
    /// Sends an API query to EngageBay.
    /// </summary>
    private async Task<HttpResponseMessage?> SendRequestAsync(string endpoint, HttpMethod method, bool encodeJson, object? values = null, bool returnNotFoundAsNull = false, CancellationToken cancellationToken = default)
    {
        endpoint.CheckNotNull();

        // Serialize request.
        var content = values == null ? null : encodeJson ? 
            JsonSerializer.Serialize(values, EngageBaySerializerOptions.Default) :
            values is IDictionary<string, object> dict ? dict.ToQueryString() :
            values.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(values, null)).ToQueryString();
        // var content = values switch
        // {
        //     null => null,
        //     IDictionary<string, object> dict => dict.ToQueryString(),
        //     _ => JsonSerializer.Serialize(values, EngageBaySerializerOptions.Default)
        // };

        var requestUrl = endpoint;
        if ((method == HttpMethod.Get || method == HttpMethod.Delete) && !encodeJson && !string.IsNullOrEmpty(content))
        {
            requestUrl += "?" + content;
            content = null;
        }

        // Log request.
        if (_logger?.IsEnabled(LogLevel.Information) == true)
        {
            _logger?.LogInformation("{Method} {BaseAddress}{RequestUrl}    {Content}", method, _httpClient.BaseAddress, requestUrl, content ?? string.Empty);
        }
        
        using var request = new HttpRequestMessage(method, requestUrl);
        request.Content = content != null ? new StringContent(content, Encoding.UTF8, encodeJson ? ContentJson : ContentUrl) : null;
        var response = await _httpClient.SendAsync(request, cancellationToken);

        // Return null instead of throwing an error when object is not found.
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            if (returnNotFoundAsNull)
            {
                return null;
            }
            var msg = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException(Res.ResponseBadRequest.FormatInvariant(msg));
        }
        response.EnsureSuccessStatusCode();
        return response;
    }
}
