using System;
using Dwolla.Helpers;
using Dwolla.Models;

namespace Dwolla.Services
{
    public class DwollaRequestService
    {
        public DwollaResponse<string> MakeRequest(RequestTransactionOptions options)
        {
            var url = Urls.Requests;

            var urlWithParams = ParameterBuilder.ApplyAllParameters(options, url);

            Console.WriteLine("Url: {0}", urlWithParams);

            //var rawResponse = Requestor.PostString(urlWithParams);

            //Console.WriteLine("Response: {0}", rawResponse);

            return new DwollaResponse<string>();
        }
    }
}
