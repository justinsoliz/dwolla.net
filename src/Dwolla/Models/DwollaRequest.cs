using System;

namespace Dwolla.Models
{
    public class DwollaRequest
    {
        /// <summary>
        /// Request ID
        /// </summary>
        public string Id { get; set; }

        public decimal Amount { get; set; }
        
        public DateTime DateRequested { get; set; }
        
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

        public DwollaTransaction Transaction { get; set; }

        public string Notes { get; set; }

        public string CancelledBy { get; set; }

        public DateTime? DateCancelled { get; set; }

        public bool SenderAssumeFee { get; set; }

        public bool SenderAssumeAdditionalFees { get; set; }

        //public DwollaFee[] AdditionalFees { get; set; }
    }
}
