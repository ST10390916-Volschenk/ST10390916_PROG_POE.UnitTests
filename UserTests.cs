//ST10390916
//All work is my own unless otherwise cited or referenced.

using ST10390916_PROG_POE.Data;
using ST10390916_PROG_POE.Models;

namespace ST10390916_PROG_POE.UnitTests
{
    [TestClass]
    public class UserTests
    {
        /// <summary>
        /// Runs the test with valid inputs and checks if the user is added by comparing the expected message
        /// </summary>
        [TestMethod]
        public void AddNewUser_ValidInput_ReturnsCorrectMessage()
        {
            //Arrange
            User user = new User();
            user.FirstName = "Calvin";
            user.Surname = "Webb";
            user.Email = "email@email.com";
            user.Password = "password";
            user.PhoneNumber = "1234567890";
            user.UserRole = Role.Manager;

            //Act
            string result = user.AddNewUser(user);
            string expected = "";

            //Assert
            Assert.AreEqual(expected, result);

            //remove test data from database
            AppDbContext context = new AppDbContext();
            context.users.Remove(user);

        }

        /// <summary>
        /// Runs the test with valid inputs and checks if the user exsists by comparing the userIDs that are returned
        /// </summary>
        [TestMethod]
        public void CheckUser_ValidInput_ReturnsCorrectUserID()
        {
            //Arrange
            User user = new User();
            user.Email = "lecturer@lecturer.com";
            user.Password = "lecturer";

            //Act
            int result = user.CheckUser(user.Email, user.Password);
            int expected = 23;

            //Assert
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// Runs the test with invalid inputs and checks if the user does not exsist by comparing the userIDs that are returned
        /// </summary>
        [TestMethod]
        public void CheckUser_InvalidInput_ReturnsMinusOne()
        {
            //Arrange
            User user = new User();
            user.Email = "emailThatDoesNotExsist";
            user.Password = "somePassword";

            //Act
            int result = user.CheckUser(user.Email, user.Password);
            int expected = -1;

            //Assert
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// Runs the test with valid inputs and checks if the correct user is returned by comparing the unique email address
        /// The GetUser parameter is the userID. The userID is a non nullable type so won't be null at any time
        /// </summary>
        [TestMethod]
        public void GetUser_ValidInput_ReturnsCorrectUser()
        {
            //Arrange
            User user = new User();
            user.UserID = 23;

            //Act
            string result = user.GetUser(user.UserID).Email;
            string expected = "lecturer@lecturer.com";

            //Assert
            Assert.AreEqual(expected, result);

        }

    }
}
