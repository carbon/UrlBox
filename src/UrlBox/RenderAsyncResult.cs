﻿using System.Text.Json.Serialization;

namespace UrlBox;

public sealed class RenderAsyncResult
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("renderId")]
    public required string RenderId { get; init; }

    [JsonPropertyName("statusUrl")]
    public required string StatusUrl { get; init; }
}