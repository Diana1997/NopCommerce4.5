using Newtonsoft.Json;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Responses
{
    public class QueueCountResponse
    {
        [JsonProperty("count")]
        public int Count { set; get; }
    }
}