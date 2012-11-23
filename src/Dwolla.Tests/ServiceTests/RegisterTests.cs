using System;
using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class RegisterTests : DwollaServiceTest
    {
        [Test]
        public void It_should_register_a_new_dwolla_user()
        {
            // arrange
            var registerService = new DwollaRegisterService();

            var options = new RegisterOptions {
                ClientId = TestAppKey,
                ClientSecret = TestAppSecret,
                Email = TestEmail,
                Password = "P@ssword",
                Pin = "1111",
                FirstName = "TestFirst",
                LastName = "TestLast",
                Address = "555 Not Real",
                City = "Seattle",
                State = "WA",
                Zip = "98119",
                Phone = "2065551234",
                DateOfBirth = new DateTime(1980, 1, 1),
                AccountType = "Personal",
                AcceptTerms = true
            };

            // act
            DwollaResponse<DwollaUser> response = registerService.RegisterUser(options);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
