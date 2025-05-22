using System.Text.Json.Serialization;

namespace UrlBox;

public sealed class RenderResult
{
    [JsonPropertyName("renderUrl")]
    public required string RenderUrl { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }
}