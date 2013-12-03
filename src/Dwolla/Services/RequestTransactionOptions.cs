using Newtonsoft.Json;

namespace Dwolla.Services
{
    public class RequestTransactionOptions
    {
        /// <summary>
        /// A valid OAuth token
        /// </summary>
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }

        /// <summary>
        /// Identification of the user to request funds from. Must be the Dwolla, 
        /// Facebook, Twitter, phone or email identifier
        /// </summary>
        [JsonProperty("sourceId")]
        public string SourceId { get; set; }

        /// <summary>
        /// Type of destination user. Defaults to Dwolla. Can be Dwolla, Facebook, 
        /// Twitter, Email, or Phone
        /// </summary>
        [JsonProperty("sourceType")]
        public string SourceType { get; set; }

        /// <summary>
        /// Amount of funds to request from the source user.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Amount of the facilitator fee to override. Only applicable if the 
        /// facilitator fee feature is enabled. If set to 0, facilitator fee is 
        /// dsiabled for transaction. Cannot exceed 25% of the 'amount'.
        /// </summary>
        [JsonProperty("facilitatorAmount")]
        public decimal FacilitatorAmount { get; set; }

        /// <summary>
        /// Note to attach to the transaction. Limited to 250 characters.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Set to true if the fulfilling user (the user who will send the money) 
        /// will assume the Dwolla fee. Set to false if the destination user will 
        /// assume the Dwolla fee. Does not affect facilitator fees.
        /// 
        /// Default: false
        /// </summary>
        [JsonProperty("senderAssumeCosts")]
        public bool SenderAssumeCosts { get; set; }

        /// <summary>
        /// Set to true if the fulfilling user (the user who will send the money) 
        /// will assume all Facilitator fees. Set to false if the destination user 
        /// will assume all Facilitator fees. Does not affect the Dwolla fee.
        /// 
        /// Default: false
        /// </summary>
        [JsonProperty("senderAssumeAdditionalFees")]
        public bool SenderAssumeAdditionalFees { get; set; }
    }
}
