using System.Text.Json.Serialization;

namespace Dima.Core.Responses;
public class Response<TData>
{
    public Response(TData? data, int code = 200, string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }

    [JsonConstructor]
    public Response()
        => _code = Configuration.DefaultStatusCode;

    private readonly int _code;
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess
        => _code is >= 200 and <= 299;
}