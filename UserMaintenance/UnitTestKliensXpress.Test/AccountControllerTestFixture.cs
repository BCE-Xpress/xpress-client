using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Assert = NUnit.Framework.Assert;

namespace UnitTestKliensXpress.Test
{
    internal class AccountControllerTestFixture
    {
        [
       Test,
       TestCase("abcd1234", false),
       TestCase("a23", false),
       TestCase("2", false),
       TestCase("0", true)
       ]
        public void TestValidatePassword(string password, bool expectedResult)
        {

            // Arrange
            var accountController = new AccountController();


            // Act
            var actualResult = accountController.ValidatePassword(password);


            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }


        [
       Test,
       TestCase("abcd1234", false),
       TestCase("a23", false),
       TestCase("250", false),
       TestCase("22", true)
       ]
        public void TestValidateQuantity(int quantity, bool expectedResult)
        {

            // Arrange
            var accountController = new AccountController();


            // Act
            var actualResult = accountController.ValidateQuantity(quantity);


            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
