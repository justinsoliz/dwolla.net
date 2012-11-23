using System;
using System.Collections.Generic;
using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class TransactionTests : DwollaServiceTest
    {
        private string _dwollaReflectorId;

        [SetUp]
        public void Setup()
        {
            // This is the Dwolla 'test' account be careful, it's live
            // http://developers.dwolla.com/dev/docs/testing
            _dwollaReflectorId = "812-713-9234";
        }

        [Test]
        public void It_should_send_funds()
        {
            // arrange
            var transactionService = new DwollaTransactionService();

            var options = new SendTransactionOptions {
                OAuthToken = TestOAuthToken,
                Pin = TestPin,
                DestinationId = _dwollaReflectorId,
                Amount = 1,
                FacilitatorAmount = 0
            };

            // act
            DwollaResponse<string> response = transactionService
                .SendFunds(options);

            // a successful transaction returns a transactionId

            // assert
            response.Success.ShouldBeTrue();
        }


        [Test]
        public void It_should_list_a_users_transactions()
        {
            // arrange 
            var transactionService = new DwollaTransactionService();

            var options = new ListTransactionOptions {

                // OAuth token required
                OAuthToken = TestOAuthToken,

                // get transactions from last 2 days
                SinceDate = DateTime.Now.AddDays(-2).ToString()
            };

            // act
            DwollaResponse<IList<DwollaTransaction>> response = transactionService
                .GetByUser(options);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_retrieve_transaction_stats_by_oauth()
        {
            // arrange
            var transactionService = new DwollaTransactionService();

            var options = new TransactionStatsOptions {

                // OAuth token required
                OAuthToken = TestOAuthToken,

                // get transactions from the previous month
                StartDate = DateTime.Now.AddMonths(-1).ToString()
            };

            // act
            DwollaResponse<DwollaTransactionStats> response = transactionService
                .GetTransactionStats(options);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_get_transaction_by_oauth_token_and_id()
        {
            // arrange
            const string transactionId = "1240235"; // Todo: Remove TransactionId

            var transactionService = new DwollaTransactionService();

            // act
            DwollaResponse<DwollaTransaction> response = transactionService
                .GetById(transactionId, TestOAuthToken);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_get_transaction_by_app_credentials()
        {
            // arrange
            const string transactionId = "1240235"; // Todo: Remove transactionId

            var transactionService = new DwollaTransactionService();

            // act
            DwollaResponse<DwollaTransaction> response = transactionService
                .GetById(transactionId, TestAppKey, TestAppSecret);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
