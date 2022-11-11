using System;

using Xunit;

namespace UrlBox.Tests;

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

        Assert.Equal("https://api.urlbox.io/v1/a/af8e1a1ddc3eac195410260e5100e4003e2dd93f/webp?url=https%3A%2F%2Fgoogle.com%2F&full_page=true", url);
    }
}