namespace Dwolla.Helpers
{
    internal static class Urls
    {
        public static string Balances(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/balance";
        }

        public static string Contacts(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/contacts";
        }

        public static string FundingSources(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/fundingsources";
        }

        public static string Register(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/register";
        }

        public static string Requests(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/requests";
        }

        public static string Transactions(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/transactions";
        }

        public static string Users(bool sandbox = false)
        {
            return BaseUrl(sandbox) + "/users";
        }

        public static string BaseUrl(bool sandbox = false)
        {
            if (sandbox)
                return "https://uat.dwolla.com/oauth/rest";
            else
                return "https://www.dwolla.com/oauth/rest";
            
            //get { return "http://www.dwolla.com/oauth/rest"; }
        }
    }
}
