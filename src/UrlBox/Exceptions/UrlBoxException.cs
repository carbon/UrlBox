using System;

namespace UrlBox.Exceptions;

public sealed class UrlBoxException : Exception
{
    public UrlBoxException(string message) 
        : base(message) { }

    public UrlBoxException(ErrorResult error) 
        : base(error.Error.Message) 
    {
        Code = error.Error.Code;
    }

    // NoApiKeySupplied                 No API key was supplied in the request
    // UserNotFoundError                A user for that API key could not be found
    // ApiKeyNotFound                   The API key was not found
    // ProjectNotFound                  A project for the API key was not found
    // ProjectNotEnabled                The project is not enabled
    // NoPlan                           The user currently has no plan
    // NotConfirmed                     The user has not confirmed their email address
    // NotActive                        The user is not active(subscription has expired)
    // FeatureNotAvailableOnPlan        The feature is not available on the user's plan
    // InvalidOptions                   The options supplied were invalid
    // InvalidTtl                       The TTL supplied was invalid
    // NoS3BucketConfigured             The user has not configured an S3 bucket for their project
    // RateLimitExceededError           The user's rate limit has been exceeded
    // TrialUsageReached                The user's trial usage has been reached
    // HTMLProcessError                 The HTML could not be processed
    // InvalidQuery                     The query string was invalid
    // NoUrlSupplied                    No URL was supplied in the request
    // UrlWasNotAStringError            The URL supplied was not a string
    // InvalidURLExtensionError         The URL extension was invalid
    // InvalidURLError                  The URL was invalid
    // URLDoesNotResolveError           The URL does not resolve to a valid IP address
    // RenderTimeoutError               The render timed out before it could be completed
    // TokenlessRequestsNotEnabled      The user has not enabled tokenless(basic render link) requests
    // NoQuerySent                      No query was sent in the request
    // TokenNotMatchedError             The token supplied did not match the token for the query string
    // EngineResponseNotOkError         The rendering engine was not able to generate the render
    // EngineAsyncResponseNotOkError    The rendering engine was not able to generate the render(async)
    // TimedOutError                    The request timed out
    // NoRenderIdProvided               No render ID was provided(when looking up a render)
    // ApiKeyWrongFormat                The API key was not sent in the correct format
    public string? Code { get; }

    // 400 | BadRequest
    // 401 | Unauthorized
    // 429 | Too many requests - Rate limit was reached
    // 500 | Internal Server Error
    // 502 | Bad Gateway
    // 503 | Service unavailable
    public int Status { get; init; }
}
