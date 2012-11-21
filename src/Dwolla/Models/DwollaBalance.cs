using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaBalance
    {
        public bool Success { get; set; }

        public string Message { get; set; }


        [JsonProperty("Response")]
        public decimal Amount { get; set; }
    }
}
