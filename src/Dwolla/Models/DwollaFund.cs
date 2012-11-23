using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaFund
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("Type")]
        public string FundType { get; set; }

        public bool Verified { get; set; }

        public string ProcessingType { get; set; }

        public decimal? Balance { get; set; }
    }
}