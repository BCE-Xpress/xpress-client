using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KliensTest.Tesztek;
using NUnit.Framework;
using static KliensTest.Tesztek.UserManagement;

namespace KliensTest
{
    public class UserManagementTesting
    {
        [
        Test,
        TestCase("Abcd1234"),
        TestCase("Abcd1234567"),
]
        public void TestPassword(string password)
        {
            // Arrange
            var accountController = new User();

            // Act
            var actualResult = accountController.Jelszo;

            // Assert
        }
    }
}
