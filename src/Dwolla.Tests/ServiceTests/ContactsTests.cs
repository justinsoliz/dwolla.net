using System.Collections.Generic;
using Dwolla.Models;
using Dwolla.Services;
using Dwolla.Tests.Helpers;
using NUnit.Framework;

namespace Dwolla.Tests.ServiceTests
{
    [TestFixture]
    public class ContactsTests : DwollaServiceTest
    {
        [Test]
        public void It_should_return_a_list_of_the_users_contacts()
        {
            // arrange
            var contactService = new DwollaContactService();

            // act
            DwollaResponse<IList<DwollaContact>> response = contactService.GetUserContacts(TestOAuthToken);

            // assert
            response.Success.ShouldBeTrue();
        }

        [Test]
        public void It_should_return_a_list_of_nearby_contacts()
        {
            // arrange
            var contactService = new DwollaContactService();

            // act
            DwollaResponse<IList<DwollaContact>> response = contactService.GetNearbyContacts(
                TestAppKey, TestAppSecret);

            // assert
            response.Success.ShouldBeTrue();
        }
    }
}
