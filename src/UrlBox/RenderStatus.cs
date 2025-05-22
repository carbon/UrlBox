using System.Text.Json.Serialization;

namespace UrlBox;

public sealed class RenderStatus
{
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("renderId")]
    public required string RenderId { get; init; }

    [JsonPropertyName("renderUrl")]
    public string? RenderUrl { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }
}
