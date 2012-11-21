using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class BalanceTests : DwollaServiceTest
    {
        [Test]
        public void It_should_return_a_balance()
        {
            // arrange
            var balanceService = new DwollaBalanceService();

            // act
            var balance = balanceService.Get(OAuthToken);

            // assert
            balance.Success.ShouldBeTrue();
        }
    }
}
