using System.Collections.Generic;
using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;

namespace Dwolla.Services
{
    public class DwollaUserService
    {
        public DwollaResponse<DwollaUser> GetFullAccount(string oAuthToken)
        {
            string url = Urls.Users + "?oauth_token=" +
                HttpUtility.UrlEncode(oAuthToken);

            var rawResponse = Requestor.GetString(url);

            var dwollaReponse = Mapper<DwollaResponse<DwollaUser>>
                .MapFromJson(rawResponse);

            return dwollaReponse;
        }

        public DwollaResponse<DwollaUser> GetBasicAccount(string userId, string key, string secret)
        {
            var parameters = new Dictionary<string, object>()
                {
                    { "client_id", key },
                    {"client_secret", secret }
                };

            var endPoint = string.Format("{0}/{1}", Urls.Users, userId);
            string encodedUrl = HttpHelper.BuildUrl(endPoint, parameters);

            var rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<DwollaUser>>.MapFromJson(rawResponse);
        }
    }
}
