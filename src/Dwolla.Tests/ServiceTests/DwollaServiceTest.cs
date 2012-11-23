using System.Configuration;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    public class DwollaServiceTest
    {
        protected string TestAppKey;
        protected string TestAppSecret;
        protected string TestEmail;
        protected string TestOAuthToken;
        protected string TestPin;
        protected string TestFundId;

        [SetUp]
        public void setup()
        {
            TestAppKey = ConfigurationManager.AppSettings["TestAppKey"];
            TestAppSecret = ConfigurationManager.AppSettings["TestAppSecret"];
            TestEmail = ConfigurationManager.AppSettings["TestEmail"];
            TestOAuthToken = ConfigurationManager.AppSettings["TestAccessToken"];
            TestPin = ConfigurationManager.AppSettings["TestPin"];
            TestFundId = ConfigurationManager.AppSettings["TestFundId"];
        }
    }
}
