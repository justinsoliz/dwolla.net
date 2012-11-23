namespace Dwolla.Services
{
    public class FulfillOptions
    {
        /// <summary>
        /// A valid OAuth token
        /// </summary>
        public string OAuthToken { get; set; }

        /// <summary>
        /// The request ID to fulfill
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// User's PIN associated with their account
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Amount to pay for the request. The amount specified here must be 
        /// greater than the request amount, otherwise this call will fail.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Note to attach to the transaction. Limited to 250 characters.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Id of funding source to send funds from. Defaults to Balance. Balance 
        /// sourced transfers process immdiately. Non-balanced sourced transfers 
        /// may process immediately or take up to five business days. 
        /// </summary>
        public string FundsSource { get; set; }

        /// <summary>
        /// Set to true if the user will assume the Dwolla fee. Set to false if 
        /// the destination user will assume the Dwolla fee. Does not affect 
        /// facilitator fees. Defaults to false.
        /// </summary>
        public bool AssumeCosts { get; set; }
    }
}
