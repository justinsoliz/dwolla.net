using System;
using System.Collections.Generic;
using Dwolla.Helpers;
using Dwolla.Models;
using RestSharp;

namespace Dwolla.Services
{
    public class DwollaTransactionService
    {
        public DwollaResponse<string> SendFunds(SendTransactionOptions options)
        {
            var url = Urls.Transactions + "/send";

            var client = new RestClient();

            var data = new {
                oauth_token = options.OAuthToken,
                pin = options.Pin,
                destinationId = options.DestinationId,
                amount = options.Amount,
                assumeCosts = options.AssumeCosts,
                destinationType = options.DestinationType,
                facilitatorAmount = options.FacilitatorAmount,
                fundsSource = options.FundsSource,
                notes = options.Notes,
            };

            var request = new RestRequest(url, Method.POST) {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            var response = client.Execute(request);

            return Mapper<DwollaResponse<string>>.MapFromJson(response.Content);
        }

        public DwollaResponse<IList<DwollaTransaction>> GetByUser(ListTransactionOptions options)
        {
            var parameters = new Dictionary<string, object>()
                {
                    {"oauth_token", options.OAuthToken},
                    {"sinceDate", options.SinceDate},
                    {"types", options.Types},
                    {"limit", options.Limit},
                    {"skip", options.Limit}
                };

            string encodedUrl = HttpHelper.BuildUrl(Urls.Transactions, parameters);

            var rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<IList<DwollaTransaction>>>.MapFromJson(rawResponse);
        }

        public DwollaResponse<DwollaTransactionStats> GetTransactionStats(TransactionStatsOptions options)
        {
            var url = Urls.Transactions + "/stats";

            var parameters = new Dictionary<string, object>()
                {
                    {"oauth_token", options.OAuthToken},
                    {"types", options.StatTypes},
                    {"startDate", options.StartDate},
                    {"endDate", options.EndDate}
                };

            string encodedUrl = HttpHelper.BuildUrl(url, parameters);

            var rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<DwollaTransactionStats>>.MapFromJson(rawResponse);
        }

        public DwollaResponse<DwollaTransaction> GetById(string transactionId, string oAuthToken)
        {
            var parameters = new Dictionary<string, object> { { "oauth_token", oAuthToken } };

            var endpoint = string.Format("{0}/{1}", Urls.Transactions, transactionId);

            string encodedUrl = HttpHelper.BuildUrl(endpoint, parameters);

            string rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<DwollaTransaction>>.MapFromJson(rawResponse);
        }

        // Todo: not sure if this still works
        public DwollaResponse<DwollaTransaction> GetById(
            string transactionId, string appKey, string appSecret)
        {
            var parameters = new Dictionary<string, object>()
                {
                    {"client_id", appKey},
                    {"client_secret", appSecret}
                };

            var endpoint = string.Format("{0}/{1}", Urls.Transactions, transactionId);

            string encodedUrl = HttpHelper.BuildUrl(endpoint, parameters);

            string rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<DwollaTransaction>>.MapFromJson(rawResponse);
        }
    }
}
