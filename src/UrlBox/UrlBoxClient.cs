using System;
using System.Buffers;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UrlBox;

public sealed class UrlBoxClient
{
    private const string baseUri = "https://api.urlbox.io/v1";

    private readonly HttpClient httpClient = new ();

    private readonly string _apiKey;
    private readonly byte[] _apiSecret;

    public UrlBoxClient(string apiKey, string apiSecret)
    {
        ArgumentNullException.ThrowIfNull(apiKey);
        ArgumentNullException.ThrowIfNull(apiSecret);

        _apiKey = apiKey;
        _apiSecret = Encoding.ASCII.GetBytes(apiSecret);
    }
 
    public async Task<MemoryStream> TakeScreenshotAsync(ScreenshotRequest request)
    {
        var url = GetSignedUrl(request);

        using var response = await httpClient.GetAsync(url).ConfigureAwait(false);
        using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

        var ms = new MemoryStream();

        await stream.CopyToAsync(ms).ConfigureAwait(false);

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