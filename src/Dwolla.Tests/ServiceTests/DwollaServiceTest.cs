using System.Configuration;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    public class DwollaServiceTest
    {
        protected string AppKey;
        protected string AppSecret;
        protected string OAuthToken;
        protected string TestPin;
        protected string TestFundId;

        [SetUp]
        public void setup()
        {
            AppKey = ConfigurationManager.AppSettings["TestAppKey"];
            AppSecret = ConfigurationManager.AppSettings["TestAppSecret"];
            OAuthToken = ConfigurationManager.AppSettings["TestAccessToken"];
            TestPin = ConfigurationManager.AppSettings["TestPin"];
            TestFundId = ConfigurationManager.AppSettings["TestFundId"];
        }
    }
}
