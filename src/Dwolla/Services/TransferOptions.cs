using Newtonsoft.Json;

namespace Dwolla.Services
{
    public class TransferOptions
    {
        /// <summary>
        /// A valid OAuth token
        /// </summary>
        [JsonProperty("oauth_token")]
        public string OAuthToken { get; set; }

        /// <summary>
        /// User's PIN associated with their account
        /// </summary>
        [JsonProperty("pin")]
        public string Pin { get; set; }

        /// <summary>
        /// Id of funding source to deposit funds to (withdraw) or from (deposit)
        /// </summary>
        [JsonProperty("fundsSource")]
        public string FundsSource { get; set; }

        /// <summary>
        /// Amount of funds to withdraw from the Dwolla account, and 
        /// deposit into the bank account
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
