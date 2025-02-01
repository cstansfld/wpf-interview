using Microsoft.Extensions.Logging;

namespace Wpf.Interview.Models.Handlers;

public class LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> _logger)
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
#pragma warning disable S2139 // Exceptions should be either logged or rethrown but not both
        try
        {
            _logger.LogInformation("Outgoing HTTP request: {Version} {Method} {Scheme}://{Host}{PathAndQuery} - {Length} - {StatusCode}",
                request.Version, request.Method, request.RequestUri?.Scheme, request.RequestUri?.Host,
                request.RequestUri?.PathAndQuery, request.Headers.ToString().Length + (request.Content?.Headers.ContentLength ?? 0), 0);

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            _logger.LogInformation("Incoming HTTP response: {Version} {Method} {Scheme}://{Host}{PathAndQuery} - {Length} - {StatusCode}",
                response.Version, request.Method, request.RequestUri?.Scheme, request.RequestUri?.Host,
                request.RequestUri?.PathAndQuery, response.Headers.ToString().Length + (response.Content?.Headers.ContentLength ?? 0), response.StatusCode);

            return response;
        }
        catch (HttpRequestException httpreqex)
        {
            _logger.LogError(httpreqex, "Error HTTP request: {Version} {Method} {Scheme}://{Host}{PathAndQuery} - {Length} - {StatusCode}",
                request.Version, request.Method, request.RequestUri?.Scheme, request.RequestUri?.Host,
                request.RequestUri?.PathAndQuery, -1, httpreqex.StatusCode);

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error HTTP response: {Version} {Method} {Scheme}://{Host}{PathAndQuery} - {Length} - {StatusCode}",
                request.Version, request.Method, request.RequestUri?.Scheme, request.RequestUri?.Host,
                request.RequestUri?.PathAndQuery, -1, 400);

            throw;
        }
#pragma warning restore S2139 // Exceptions should be either logged or rethrown but not both
    }
}
