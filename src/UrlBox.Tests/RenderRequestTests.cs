using System.Text.Json;

namespace UrlBox.Tests;

public class RenderRequestTests
{
    private static readonly JsonSerializerOptions jso = new() { WriteIndented = true };

    [Fact]
    public void Basic()
    {
        var request = new RenderRequest {
            Url = "https://google.com/"
        };

        Assert.Equal(
            """
            {
              "url": "https://google.com/"
            }
            """, JsonSerializer.Serialize(request, jso));
    }

    [Fact]
    public void RenderHtml()
    {
        var request = new RenderRequest {
            Html = "<p>test</p>",
            FullPage = true,
            Format = "webp",
            Quality = 100,
            Retina = true            
        };

        Assert.Equal(
            """
            {
              "html": "\u003Cp\u003Etest\u003C/p\u003E",
              "full_page": true,
              "format": "webp",
              "retina": true,
              "quality": 100
            }
            """, JsonSerializer.Serialize(request, jso));
    }
}
