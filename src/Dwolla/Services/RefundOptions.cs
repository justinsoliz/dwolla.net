using Newtonsoft.Json;

namespace Dwolla.Services
{
    public class RefundOptions
    {
        /// <summary>
        /// A valid OAuth token.
        /// </summary>
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }

        /// <summary>
        /// User's account PIN.
        /// </summary>
        [JsonProperty("pin")]
        public string Pin { get; set; }

        /// <summary>
        /// The ID of the transaction to be refunded.
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// The Funding Source ID of the funding source from which the refund will be funded.
        /// </summary>
        [JsonProperty("fundsSource")]
        public string FundsSource { get; set; }

        /// <summary>
        /// Note to be attached to the refund.
        /// 
        /// Character limit: 255
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// The amount to be refunded
        /// 
        /// Partial refunds are allowed. Amount must be less than or equal to the amount of the original transaction.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

    }
}
