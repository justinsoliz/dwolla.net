using System.Collections.Generic;
using Dwolla.Helpers;
using Dwolla.Models;

namespace Dwolla.Services
{
    public class DwollaContactService : DwollaService
    {
        public DwollaContactService(bool sandbox = false)
            : base(sandbox)
        { }

        /// <summary>
        /// Use this method to retrieve the contacts' information for the 
        /// user associated with the authorized access token.
        /// </summary>
        /// <param name="oAuthToken">A valid OAuth token</param>
        /// <param name="search">Search term used to search the contacts</param>
        /// <param name="limit">Number of contacts to retrieve. Defaults to 25.</param>
        /// <param name="types">Account types to return, defaults to Dwolla and FB</param>
        /// <returns></returns>
        public DwollaResponse<IList<DwollaContact>> GetUserContacts(string oAuthToken,
            string search = null, string limit = "25", string types = "Dwolla,Facebook")
        {
            var parameters = new Dictionary<string, object>()
                {
                    {"oauth_token", oAuthToken},
                    {"types", types},
                    {"limit", limit}
                };

            if (!string.IsNullOrWhiteSpace(search))
                parameters.Add("search", search);

            string encodedUrl = HttpHelper.BuildUrl(Urls.Contacts(Sandbox), parameters);

            string rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<IList<DwollaContact>>>.MapFromJson(rawResponse);
        }

        /// <summary>
        /// Use this method to retrieve nearby Dwolla spots within the range of the
        /// provided lattitude and longitude. Halft of the limit are returned as 
        /// spots with closest proximity. The other half of the spots returned 
        /// as random spots within the range.
        /// </summary>
        /// <param name="key">Consumer key for the application</param>
        /// <param name="secret">Consumer secret for the application</param>
        /// <param name="latitude">Current lattitude</param>
        /// <param name="longitude">Current longitude</param>
        /// <param name="range">Range to retireve spots for (in miles), defaults to 10</param>
        /// <param name="limit">Number of spots to retrieve, defaults to 10</param>
        /// <returns></returns>
        public DwollaResponse<IList<DwollaContact>> GetNearbyContacts(string key, string secret,
            string latitude = null, string longitude = null, string range = null, string limit = null)
        {
            var parameters = new Dictionary<string, object>()
                {
                    {"client_id", key},
                    {"client_secret", secret},
                    {"latitude", latitude},
                    {"longitude", longitude},
                    {"range", range},
                    {"limit", limit}
                };

            var endpoint = string.Format("{0}/{1}", Urls.Contacts(Sandbox), "nearby");
            string encodedUrl = HttpHelper.BuildUrl(endpoint, parameters);

            var rawResponse = Requestor.GetString(encodedUrl);

            return Mapper<DwollaResponse<IList<DwollaContact>>>.MapFromJson(rawResponse);
        }
    }
}
