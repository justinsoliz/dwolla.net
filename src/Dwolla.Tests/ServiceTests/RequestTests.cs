using System.Collections.Generic;
using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class RequestTests : DwollaServiceTest
    {
        private string _dwollaReflectorId;

        [SetUp]
        public void Setup()
        {
            _dwollaReflectorId = "812-713-9234";
        }


        [Test]
        public void It_should_make_transaction_request()
        {
            // arrange
            var requestService = new DwollaRequestService();

            var options = new RequestTransactionOptions {
                // required options
                OAuthToken = TestOAuthToken,
                SourceId = _dwollaReflectorId,
                Amount = new decimal(1.50),

                // optional
                SourceType = "Dwolla"
            };

            // act
            DwollaResponse<string> response = requestService.Request(options);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_fulfil_a_request()
        {
            // arrange
            var requestService = new DwollaRequestService();

            var options = new FulfillOptions {
                OAuthToken = TestOAuthToken,
                RequestId = "111",
                Pin = "1111"
            };

            // act
            DwollaResponse<DwollaRequest> response = requestService.Fulfill(options);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_list_pending_requests()
        {
            // arrange
            var requestService = new DwollaRequestService();

            // act
            DwollaResponse<IList<DwollaRequest>> response = requestService
                .ListPending(TestOAuthToken);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_get_request_by_id()
        {
            // arrange
            var requestId = "955";
            var requestService = new DwollaRequestService();

            // act
            DwollaResponse<DwollaRequest> response = requestService
                .GetRequest(TestOAuthToken, requestId);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
