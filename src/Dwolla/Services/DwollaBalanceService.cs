using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;

namespace Dwolla.Services
{
    public class DwollaBalanceService
    {
        public DwollaBalance Get(string oAuthToken)
        {
            var url = Urls.Balances + "?oauth_token=" + 
                HttpUtility.UrlEncode(oAuthToken);

            var response = Requestor.GetString(url);

            return Mapper<DwollaBalance>.MapFromJson(response);
        }
    }
}
