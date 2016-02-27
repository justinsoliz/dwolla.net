using System.Collections.Generic;
using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;
using RestSharp;

namespace Dwolla.Services
{
    public class DwollaFundingService : DwollaService
    {
        public DwollaFundingService(bool sandbox = false)
            : base(sandbox)
        { }

        /// <summary>
        /// Get a list of funding sources
        /// Use this method to retrieve a list of verified funding sources 
        /// for the user associated with the authorized access token.
        /// </summary>
        /// <param name="oAuthToken">A valid OAuth token</param>
        /// <returns></returns>
        public DwollaResponse<IList<DwollaFund>> List(string oAuthToken)
        {
            var url = Urls.FundingSources(Sandbox, true) + "?oauth_token=" +
                HttpUtility.UrlEncode(oAuthToken);

            var response = Requestor.GetString(url);

            return Mapper<DwollaResponse<IList<DwollaFund>>>.MapFromJson(response);
        }

        /// <summary>
        /// Get a funding source details by ID
        /// Use this method to retrieve a verified funding source by identifier 
        /// for the user associated with the authorized access token.
        /// </summary>
        /// <param name="oAuthToken">A valid OAuth token</param>
        /// <param name="testFundId">Funding source identifier of the funding source being requested.</param>
        /// <returns>Dwolla transaction</returns>
        public DwollaResponse<DwollaFund> GetById(string oAuthToken, string testFundId)
        {
            var url = string.Format("{0}/{1}?oauth_token={2}", Urls.FundingSources(Sandbox, true),
                testFundId, HttpUtility.UrlEncode(oAuthToken));

            var response = Requestor.GetString(url);

            return Mapper<DwollaResponse<DwollaFund>>.MapFromJson(response);
        }

        /// <summary>
        /// Withdraw funds from Dwolla account
        /// Use this method to withdraw funds from a DWolla account, and into a bank 
        /// account, for the user with the given authorized access token.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Dwolla transaction</returns>
        public DwollaResponse<DwollaTransaction> Withdraw(TransferOptions options)
        {
            var url = string.Format("{0}/{1}/withdraw", Urls.FundingSources(Sandbox, true), options.FundsSource);
            
            var data = new {
                oauth_token = options.OAuthToken,
                pin = options.Pin,
                amount = options.Amount
            };

            var request = new RestRequest(url, Method.POST) {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            var response = Client.Execute(request);

            return Mapper<DwollaResponse<DwollaTransaction>>.MapFromJson(response.Content);
        }

        /// <summary>
        /// Deposit funds into dwolla account
        /// Use this method to deposit funds from a bank account, and into a Dwolla 
        /// account for the user with the given authorized access token. 
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Dwolla transaction</returns>
        public DwollaResponse<DwollaTransaction> Deposit(TransferOptions options)
        {
            var url = string.Format("{0}/{1}/deposit", Urls.FundingSources(Sandbox, true), options.FundsSource);
            
            var data = new {
                oauth_token = options.OAuthToken,
                pin = options.Pin,
                amount = options.Amount
            };

            var request = new RestRequest(url, Method.POST) {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            var response = Client.Execute(request);

            return Mapper<DwollaResponse<DwollaTransaction>>.MapFromJson(response.Content);
        }
    }
}
