namespace Dwolla.Helpers
{
    internal static class Urls
    {
        public static string Balances
        {
            get { return BaseUrl + "/balance"; }
        }

        public static string Contacts
        {
            get { return BaseUrl + "/contacts"; }
        }

        public static string FundingSources
        {
            get { return BaseUrl + "/fundingsources"; }
        }

        public static string Requests
        {
            get { return BaseUrl + "/requests"; }
        }

        public static string Transactions
        {
            get { return BaseUrl + "/transactions"; }
        }

        public static string Users
        {
            get { return BaseUrl + "/users"; }
        }

        public static string BaseUrl
        {
            get { return "https://www.dwolla.com/oauth/rest"; }
            //get { return "http://www.dwolla.com/oauth/rest"; }
        }
    }
}
