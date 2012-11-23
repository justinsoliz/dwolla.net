using System.Collections.Generic;
using Dwolla.Helpers;
using Dwolla.Models;
using RestSharp;

namespace Dwolla.Services
{
    public class DwollaRegisterService
    {
        public DwollaResponse<DwollaUser> RegisterUser(RegisterOptions options)
        {
            var url = Urls.Register;

            var client = new RestClient();

            var data = new {
                client_id = options.ClientId,
                client_secret = options.ClientSecret,
                email = options.Email,
                password = options.Password,
                pin = options.Pin,
                firstName = options.FirstName,
                lastName = options.LastName,
                address = options.Address,
                address2 = options.Address2,
                city = options.City,
                state = options.State,
                zip = options.Zip,
                phone = options.Phone,
                dateOfBirth = options.DateOfBirth,
                type = options.AccountType,
                organization = options.Organization,
                ein = options.Ein,
                acceptTerms = options.AcceptTerms
            };

            var request = new RestRequest(url, Method.POST) {
                RequestFormat = DataFormat.Json
            };

            request.AddBody(data);

            var response = client.Execute(request);

            return Mapper<DwollaResponse<DwollaUser>>.MapFromJson(response.Content);
        }
    }
}
