using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class UserTests : DwollaServiceTest
    {
        [Test]
        public void It_should_return_a_users_full_account_info()
        {
            // arrange
            var userService = new DwollaUserService();

            // act
            DwollaResponse<DwollaUser> response = userService.GetFullAccount(TestOAuthToken);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_return_a_users_basic_account_info()
        {
            // arrange
            var userService = new DwollaUserService();
            string userId = "812-608-0250";

            // act
            DwollaResponse<DwollaUser> response = userService.GetBasicAccount(userId, TestAppKey, TestAppSecret);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
