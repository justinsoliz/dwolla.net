using System;
using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaFee
    {
        public string Id { get; set; }

        public string DistinationId { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; }
    }
}
