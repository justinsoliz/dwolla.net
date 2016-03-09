using System.Collections.Generic;
using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;
using RestSharp;

namespace Dwolla.Services
{
    public class DwollaRequestService : DwollaService
    {
        public DwollaRequestService(bool sandbox = false)
            : base(sandbox)
        { }

        /// <summary>
        /// Request money
        /// Use this method to request funds from a source user, originating 
        /// from the user associated with the authorized access token.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public DwollaResponse<string> Request(RequestTransactionOptions options)
        {
            var url = Urls.Requests(Sandbox, true) + "?oauth_token=" +
                HttpUtility.UrlEncode(options.OAuthToken);
            
            var data = new {
                sourceId = options.SourceId,
                sourceType = options.SourceType,
                amount = options.Amount,
                facilitatorAmount = options.FacilitatorAmount,
                notes = options.Notes,
                senderAssumeCosts = options.SenderAssumeCosts,
                senderAssumeAdditionalFees = options.SenderAssumeAdditionalFees
            };

            var request = new RestRequest(url, Method.POST) {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            var response = Client.Execute(request);

            return Mapper<DwollaResponse<string>>.MapFromJson(response.Content);
        }

        /// <summary>
        /// Fulfill request 
        /// Use this method to fulfill (i.e. 'pay') a money request from the user 
        /// with the associated access token. 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public DwollaResponse<DwollaRequest> Fulfill(FulfillOptions options)
        {
            var url = string.Format("{0}/{1}/fulfill?oauth_token={2}", Urls.Requests(Sandbox, true),
                options.RequestId, HttpUtility.UrlEncode(options.OAuthToken));
            
            var data = new {
                pin = options.Pin,
                amount = options.Amount,
                notes = options.Notes,
                fundsSource = options.FundsSource,
                assumeCosts = options.AssumeCosts
            };

            var request = new RestRequest(url, Method.POST) {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            var response = Client.Execute(request);

            return Mapper<DwollaResponse<DwollaRequest>>.MapFromJson(response.Content);
        }

        /// <summary>
        /// List Pending Money Requests 
        /// Use this method to retrieve a list of pending money requests for the 
        /// user associated with the authorized access token.
        /// </summary>
        /// <param name="testOAuthToken"></param>
        /// <returns></returns>
        public DwollaResponse<IList<DwollaRequest>> ListPending(string testOAuthToken)
        {
            var url = Urls.Requests(Sandbox, true) + "?oauth_token=" +
                HttpUtility.UrlEncode(testOAuthToken);

            var response = Requestor.GetString(url);

            return Mapper<DwollaResponse<IList<DwollaRequest>>>.MapFromJson(response);
        }

        /// <summary>
        /// Request Details by ID
        /// Use this method to fetch detailed information about a money request, 
        /// identified by a specific request ID.
        /// </summary>
        /// <param name="oAuthToken">A valid OAuth token</param>
        /// <param name="requestId">Request identifier of the money request</param>
        /// <returns>DwollaRequest</returns>
        public DwollaResponse<DwollaRequest> GetRequest(string oAuthToken, string requestId)
        {
            var url = string.Format("{0}/{1}?oauth_token={2}", Urls.Requests(Sandbox, true), 
                requestId, HttpUtility.UrlEncode(oAuthToken));

            var response = Requestor.GetString(url);

            return Mapper<DwollaResponse<DwollaRequest>>.MapFromJson(response);
        }
    }
}
