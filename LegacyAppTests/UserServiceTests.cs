using System;
using Xunit;

namespace LegacyApp.tests
{
    public class UserServiceTests
    {
        [Fact]
        public void AddUsers_ReturnsFalseWhenFirstNameIsEmpty()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser(
                null, 
                "Smith",
                "Smith.Cool@gmail.com",
                DateTime.Parse("2000-01-01"),
                1);
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUsers_ThrowsExceptionWhenClientDoesntExist()
        {
            // Arrange
            var userService = new UserService();

            // Act
            Action action = () => userService.AddUser(
                "Joe", 
                "Smith",
                "Smith.Cool@gmail.com",
                DateTime.Parse("2000-01-01"),
                100);
            
            // Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void AddUsers_ReturnsTrueWithValidInput()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser(
                "John", 
                "Doe",
                "john.doe@example.com",
                DateTime.Now.AddYears(-25),
                1);
            
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddUsers_ReturnsFalseWithInvalidEmail()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser(
                "Jane", 
                "Doe",
                "invalid_email",
                DateTime.Now.AddYears(-25),
                1);
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUsers_ReturnsFalseWithAgeLessThan21()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser(
                "Young", 
                "User",
                "young.user@example.com",
                DateTime.Now.AddYears(-19),
                1);
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUsers_ReturnsFalseWithVeryImportantClient()
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.AddUser(
                "Important", 
                "Person",
                "important.person@example.com",
                DateTime.Now.AddYears(-25),
                2); // Assuming VeryImportantClient's ID is 2
            
            // Assert
            Assert.True(result); // In this case, it should return true as HasCreditLimit should be false
        }
    }
}
