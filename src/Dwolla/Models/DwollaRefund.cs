using System;
using Newtonsoft.Json;

namespace Dwolla.Models
{
    public class DwollaRefund
    {
        public string TransactionId { get; set; }

        public DateTime RefundDate { get; set; }

        public decimal Amount { get; set; }
    }
}
