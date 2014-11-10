using System;

namespace Dwolla.Models
{
    public class DwollaRequestTransaction
    {
        /// <summary>
        /// Transaction ID
        /// </summary>
        public string Id { get; set; }

        public string RequestId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ClearingDate { get; set; }

        /// <summary>
        /// Transaction status. Values: processed, pending, cancelled, failed, and 
        /// reclaimed. Fees bound to any transaction have the same status as the 
        /// parent transaction.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The requesting user entity
        /// </summary>
        public DwollaContact Source { get; set; }

        /// <summary>
        /// The requested user entity
        /// </summary>
        public DwollaContact Destination { get; set; }
    }
}
