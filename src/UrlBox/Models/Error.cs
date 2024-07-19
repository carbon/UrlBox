using System.Text.Json;
using System.Text.Json.Serialization;

namespace UrlBox.Models;

public sealed class Error
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("errors")]
    public JsonElement? Errors { get; set; }
}