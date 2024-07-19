using System.Text.Json.Serialization;

namespace UrlBox;

public sealed class RenderStatus
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("renderId")]
    public required string RenderId { get; set; }

    [JsonPropertyName("renderUrl")]
    public string? RenderUrl { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }
}
