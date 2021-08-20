using System;

using Xunit;

namespace UrlBox.Tests
{
    public class ScreenshotClientTests
    {
        [Fact]
        public void VerifySignature()
        {
            var client = new UrlBoxClient("a", "b");

            var url = client.GetSignedUrl(new ScreenshotRequest(new Uri("https://google.com"), "webp")
            {
                FullPage = true
            });

            Assert.Equal("https://api.urlbox.io/v1/a/73c4b11b2d0cd3668c95c3d6dbaded519e708205/webp?format=webp&url=https%3a%2f%2fgoogle.com%2f&full_page=true", url.ToString());
        }
    }
}