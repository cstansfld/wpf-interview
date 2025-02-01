using Polly.Retry;
using Polly;

namespace Wpf.Interview.Models.Handlers;

public class RetryDelegatingHandler : DelegatingHandler
{
    private const int MaxRetries = 2;

    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy =
        Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .RetryAsync(MaxRetries);

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        PolicyResult<HttpResponseMessage> policyResult = await _retryPolicy.ExecuteAndCaptureAsync(
            () => base.SendAsync(request, cancellationToken));

        if (policyResult.Outcome == OutcomeType.Failure)
        {
            throw new HttpRequestException(
                $"Could not send after {MaxRetries} retry attempts",
                policyResult.FinalException);
        }

        return policyResult.Result;
    }
}
