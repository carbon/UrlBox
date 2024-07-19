using System.Text.Json.Serialization;

namespace UrlBox;

public sealed class RenderResult
{
    [JsonPropertyName("renderUrl")]
    public required string RenderUrl { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }
}
