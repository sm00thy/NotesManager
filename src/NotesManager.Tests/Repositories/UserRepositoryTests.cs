using NotesManagerLib;
using NotesManagerLib.DataModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManager.Tests.Repositories
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public UserRepositoryTests()
        {
            //_userRepository = new UserRepository();
        }

        [Test]
        public async Task WhenCreatingUserAndCallAddMethodShouldAddUserToDb()
        {
            // Arrange
            var login = "TestUser";
            var password = "secret";

            // Act
            await _userRepository.AddUserAsync(login, password);
            var user = await _userRepository.GetUserAsync(login, password);

            // Assert
            Assert.AreEqual(login, user.Login);
            Assert.AreEqual(password, user.Password);
        }

        [TestCase(false, "", "password")]
        [TestCase(false, "login", "")]
        [TestCase(false, "", "")]
        [TestCase(false, "", null)]
        [TestCase(false, "login", null)]
        [TestCase(false, null, "password")]
        [TestCase(false, null, null)]
        public async Task WhenCallingValidateInputShouldReturnFalseIfOneOrTwoParametersAreEmptyStringOrNull(bool expectedResult, string login, string password)
        {
            // Arrange

            // Act
            var result = await _userRepository.ValidateInput(login, password);

            // Assert
            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public async Task WhenCallingValidateInputShouldReturnTrueAndCallGetUserAsync()
        {
            // Arrange
            var login = "TestUserValidateInput";
            var password = "secret";
            var expectedRsult = true;

            // Act
            await _userRepository.AddUserAsync(login, password);
            var result = await _userRepository.ValidateInput(login, password);
            
            // Assert
            Assert.AreEqual(expectedRsult, result);

        }


    }
}
