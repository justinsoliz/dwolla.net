using Newtonsoft.Json;

namespace Dwolla.Services
{
    public class TransactionStatsOptions
    {
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }

        [JsonProperty("types")]
        public string StatTypes { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }
    }
}
