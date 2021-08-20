using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UrlBox
{
    public sealed class UrlBoxClient
    {
        private const string baseUri = "https://api.urlbox.io/v1";

        private readonly HttpClient httpClient = new ();

        private readonly string apiKey;
        private readonly byte[] apiSecret;

        public UrlBoxClient(string apiKey, string apiSecret)
        {
            this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            this.apiSecret = Encoding.ASCII.GetBytes(apiSecret);
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

            return baseUri + "/" + apiKey + "/" + signature + "/" + request.Format + queryString;
        }

        private string SignQueryString(string queryString)
        {
            using var hmac = new HMACSHA1(apiSecret);

            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(queryString.Substring(1)));

            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
