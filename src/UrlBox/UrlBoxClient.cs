using System.Buffers;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using UrlBox.Exceptions;

namespace UrlBox;

public sealed class UrlBoxClient
{
    private const string baseUri = "https://api.urlbox.com/v1";

    private readonly HttpClient httpClient = new(new SocketsHttpHandler {
        AllowAutoRedirect = true,
        MaxAutomaticRedirections = 20,
       
    }) { Timeout = TimeSpan.FromMinutes(15) };

    private readonly string _apiKey;
    private readonly byte[] _apiSecret;

    public UrlBoxClient(string apiKey, string apiSecret)
    {
        ArgumentNullException.ThrowIfNull(apiKey);
        ArgumentNullException.ThrowIfNull(apiSecret);

        _apiKey = apiKey;
        _apiSecret = Encoding.ASCII.GetBytes(apiSecret);
    }

    public async Task<RenderResult> RenderAsync(RenderRequest request)
    {
        var secret = Encoding.ASCII.GetString(_apiSecret);

        var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"https://api.urlbox.com/v1/render/sync") {
            Headers = {
                { "Authorization", $"Bearer {secret}" }
            },
            Content = new ByteArrayContent(JsonSerializer.SerializeToUtf8Bytes(request)) {
                Headers = {
                    { "Content-Type", MediaTypeNames.Application.Json }
                }
            }
        };

        // After 95 seconds, if the render has not yet been generated, the API will return a 307 Temporary Redirect response with a Location header set to a temporary redirect URL.

        using var response = await httpClient.SendAsync(httpRequest).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            if (response.Content.Headers.ContentType?.MediaType is MediaTypeNames.Application.Json)
            {
                var result = (await response.Content.ReadFromJsonAsync<ErrorResult>())!;

                throw new UrlBoxException(result);
            }
            else
            {
                var text = await response.Content.ReadAsStringAsync();

                throw new Exception(text);
            }
        }

        return (await response.Content.ReadFromJsonAsync<RenderResult>())!;

    }

    public async Task<MemoryStream> TakeScreenshotAsync(ScreenshotRequest request)
    {
        var ms = new MemoryStream();

        var url = GetSignedUrl(request);

        using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        await response.Content.CopyToAsync(ms).ConfigureAwait(false);

        ms.Position = 0;

        return ms;
    }

    public string GetSignedUrl(ScreenshotRequest request)
    {
        string queryString = request.ToQueryString();

        string signature = SignQueryString(queryString);

        return $"{baseUri}/{_apiKey}/{signature}/{request.Format}{queryString}";
    }

    private string SignQueryString(string queryString)
    {
        var rentedBuffer = ArrayPool<byte>.Shared.Rent(Encoding.UTF8.GetMaxByteCount(queryString.Length));

        try
        {
            int byteCount = Encoding.UTF8.GetBytes(queryString.AsSpan(1), rentedBuffer);

            Span<byte> hash = stackalloc byte[20];

            HMACSHA1.HashData(_apiSecret, rentedBuffer.AsSpan(0, byteCount), hash);

            return Convert.ToHexString(hash).ToLowerInvariant();
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(rentedBuffer);
        }
    }
}