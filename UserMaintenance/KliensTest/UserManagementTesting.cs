using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using KliensTest.Tesztek;

namespace KliensTest
{
    public class UserManagementTesting
    {
        [Fact]
        public void Add_CreateUser()
        {

            //Arrange
            var userManagement = new UserManagement();


            //Act
            userManagement.Add(new("Andris"));

            //Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser); // Ellenorzes, hogy a usermanagement list nem ures
            Assert.Equal("Andris", savedUser.Firstname);
            Assert.False(savedUser.VerifiedName);
        }

    }
}
