using System.Collections.Generic;
using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class FundingSourcesTests : DwollaServiceTest
    {
        [Test]
        public void It_should_retrieve_a_lists_of_funding_sources()
        {
            // arrange
            var fundingService = new DwollaFundingService();

            // act
            DwollaResponse<IList<DwollaFund>> response = fundingService
                .List(TestOAuthToken);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_get_a_funding_source_by_id()
        {
            // arrange
            var fundingService = new DwollaFundingService();

            // act
            DwollaResponse<DwollaFund> response = fundingService
                .GetById(TestOAuthToken, TestFundId);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_withdraw_from_funding_source()
        {
            // arrange
            var fundingService = new DwollaFundingService();

            var options = new TransferOptions {
                OAuthToken = TestOAuthToken,
                Pin = TestPin,
                FundsSource = TestFundId,
                Amount = 1
            };

            // act
            DwollaResponse<DwollaTransaction> response = fundingService
                .Withdraw(options);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_deposit_funds_from_funding_source()
        {
            // arrange
            var fundingService = new DwollaFundingService();

            var options = new TransferOptions {
                OAuthToken = TestOAuthToken,
                Pin = TestPin,
                FundsSource = TestFundId,
                Amount = 1
            };

            // act
            DwollaResponse<DwollaTransaction> response = fundingService
                .Deposit(options);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
