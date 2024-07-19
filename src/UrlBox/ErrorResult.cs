using System.Text.Json.Serialization;

using UrlBox.Models;

namespace UrlBox;

public sealed class ErrorResult
{
    [JsonPropertyName("error")]
    public required Error Error { get; init; }

    [JsonPropertyName("requestId")]
    public required string RequestId { get; init; }
}

// {
//   "error":{
//     "message":"Invalid options, please check errors",
//     "code":"InvalidOptions",
//     "errors":{
//       "input_type":["Url or Html option is always required"]
//     }
//   },
//   "requestId":"df6affbe-3506-4f23-aa83-b6ac3d0d552b"
// }