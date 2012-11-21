using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class RequestTests : DwollaServiceTest
    {
        private string _dwollaAccountId;

        [SetUp]
        public void Setup()
        {
            _dwollaAccountId = "812-608-0250";
        }

        
        [Test]
        public void It_should_make_transaction_request()
        {
            // arrange
            var requestService = new DwollaRequestService();

            var options = new RequestTransactionOptions {
                // required options
                OAuthToken = OAuthToken,
                SourceId = _dwollaAccountId,
                Amount = new decimal(1.50),

                // optional
                SourceType = "Dwolla"
            };

            // act
            DwollaResponse<string> response = requestService
                .MakeRequest(options);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
