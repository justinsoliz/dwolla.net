using Newtonsoft.Json;

namespace Dwolla.Services
{
    public class RequestTransactionOptions
    {
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }

        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        [JsonProperty("sourceType")]
        public string SourceType { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("facilitatorAmount")]
        public decimal FacilitatorAmount { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
