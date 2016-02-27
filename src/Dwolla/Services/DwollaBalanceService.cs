using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;

namespace Dwolla.Services
{
    public class DwollaBalanceService : DwollaService
    {
        public DwollaBalanceService(bool sandbox = false)
            : base(sandbox)
        { }

        public DwollaBalance Get(string oAuthToken)
        {
            var url = Urls.Balances(Sandbox, true) + "?oauth_token=" + 
                HttpUtility.UrlEncode(oAuthToken);

            var response = Requestor.GetString(url);

            return Mapper<DwollaBalance>.MapFromJson(response);
        }
    }
}
