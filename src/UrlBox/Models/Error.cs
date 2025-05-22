using System.Text.Json;
using System.Text.Json.Serialization;

namespace UrlBox.Models;

public sealed class Error
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("code")]
    public string? Code { get; init; }

    [JsonPropertyName("errors")]
    public JsonElement? Errors { get; init; }
}