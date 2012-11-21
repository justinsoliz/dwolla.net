namespace Dwolla.Services
{
    public class ListTransactionOptions
    {
        public string OAuthToken { get; set; }
        public string SinceDate { get; set; }
        public string Types { get; set; }
        public string Limit { get; set; }
        public string Skip { get; set; }
    }
}
