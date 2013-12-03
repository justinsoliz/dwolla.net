using Newtonsoft.Json;

namespace Dwolla.Services
{
    public class SendTransactionOptions
    {
        /// <summary>
        /// A valid OAuth token
        /// </summary>
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }

        /// <summary>
        /// User's pin associated with their account
        /// </summary>
        [JsonProperty("pin")]
        public string Pin { get; set; }

        /// <summary>
        /// Identification of the user to send funds to. Must be the Dwolla, 
        /// Facebook, Twitter, phone, or email identifier
        /// </summary>
        [JsonProperty("destinationId")]
        public string DestinationId { get; set; }

        /// <summary>
        /// Defaults to Dwolla, options: Dwolla, Facebook, Twitter, Phone, or Email 
        /// </summary>
        [JsonProperty("destinationType")]
        public string DestinationType { get; set; }

        /// <summary>
        /// Amount of fund to transfer to destination user, Example: 1.50
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Amount of the facilitator fee to override. Only applicable if the 
        /// facilitator fee feature is enabled. If set to 0, facilitator fee 
        /// is disabled for transaction. Cannot exceed 25% of 'amount'
        /// </summary>
        [JsonProperty("facilitatorAmount")]
        public decimal FacilitatorAmount { get; set; }

        /// <summary>
        /// Set to true if the user will assume the Dwolla fee. Set to false 
        /// if the destination user will assume the Dwolla fee. Does not 
        /// affect facilitator fees. Defaults to false
        /// </summary>
        [JsonProperty("assumeCosts")]
        public string AssumeCosts { get; set; }

        /// <summary>
        /// Note to attach to the transaction. Limited to 250 characters
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Id of funding source to send funds from. Defaults to Balance. 
        /// Balance sourced transfers process immediately. Non-balanced 
        /// sourced transfers may process immediately or take up to 
        /// five business days.
        /// </summary>
        [JsonProperty("fundsSource")]
        public string FundsSource { get; set; }

        /// <summary>
        /// Set to true if the sending user will assume all Facilitator fees. 
        /// Set to false if the destination user will assume all Facilitator 
        /// fees. Does not affect the Dwolla fee.
        /// 
        /// Default: false
        /// </summary>
        [JsonProperty("assumeAdditionalFees")]
        public bool AssumeAdditionalFees { get; set; }
    }
}