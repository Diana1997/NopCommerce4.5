using Newtonsoft.Json;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Responses;

public class ReSyncResponse
{
    [JsonProperty("status")]
    public bool Status { set; get; }
    [JsonProperty("message")]
    public string Message { set; get; }
}