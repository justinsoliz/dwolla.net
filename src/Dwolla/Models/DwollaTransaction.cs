using System;
using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaTransaction
    {
        public string Id { get; set; }

        [JsonProperty("Date")]
        public string DateProcessed { get; set; }

        public decimal Amount { get; set; }

        public string DestinationId { get; set; }

        public string DestinationName { get; set; }

        public string SourceId { get; set; }

        [JsonProperty("Type")]
        public string TransactionType { get; set; }

        public string UserType { get; set; }

        public string Status { get; set; }

        public string ClearingDate { get; set; }

        public string Notes { get; set; }
    }
}
