using ST10390916_PROG_POE.Data;
using ST10390916_PROG_POE.Models;

namespace ST10390916_PROG_POE.UnitTests
{
    [TestClass]
    public class ClaimTests
    {

        /// <summary>
        /// Runs the test with valid inputs and checks if the claim is submitted
        /// </summary>
        [TestMethod]
        public void SubmitClaim_ValidInput_ReturnsCorrectMessage()
        {
            //Arrange
            Claim claim = new Claim();
            claim.UserID = 3000;
            claim.ClaimTitle = "Job";
            claim.HoursWorked = 5;
            claim.RatePerHour = 300;
            claim.Status = ClaimStatus.Pending;
            claim.ClaimDate = DateOnly.FromDateTime(DateTime.Now);

            //Act
            string result = claim.SubmitClaim(claim);
            string expected = "Claim submitted.";

            //Assert
            Assert.AreEqual(expected, result);

            //Remove data from database
            AppDbContext context = new AppDbContext();
            context.claims.Remove(claim);

        }

        /// <summary>
        /// Runs the test with null inputs and checks if the claim is not submitted
        /// </summary>
        [TestMethod]
        public void SubmitClaim_NullInput_ReturnsWrongMessage()
        {
            //Arrange
            Claim claim = new Claim();
            Claim testClaim = null;
            
            //Act
            string result = claim.SubmitClaim(testClaim);
            string expected = "Provide a valid claim";

            //Assert
            Assert.AreEqual(expected, result);

        }

        /// <summary>
        /// Runs the test with valid inputs and checks if a list of claims are returned. This list can be empty
        /// </summary>
        [TestMethod]
        public void GetClaimsByUserID_ValidInput_ReturnsListOfClaims()
        {
            //Arrange
            Claim claim = new Claim();
            int userID = 1; //userID 1 is already created in the database

            //Act
            List<Claim> result = claim.GetClaimsByUserID(userID);

            //Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Runs the test with any input and checks if a list of pending claims are returned. This list can be empty
        /// </summary>
        [TestMethod]
        public void GetPendingClaims_AnyInput_ReturnsListOfClaims()
        {
            //Arrange
            Claim claim = new Claim();

            //Act
            List<Claim> result = claim.GetPendingClaims();

            //Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Runs the test with valid inputs and checks if the claim is updated
        /// </summary>
        [TestMethod]
        public void UpdateClaim_AnyInput_ReturnsTrue()
        {
            //Arrange
            Claim claim = new Claim();
            

            int testID = 6; //claim with claim id 6 is already created in the database 
            ClaimStatus testStatus = ClaimStatus.Approved;

            //Act
            bool result = claim.UpdateClaim(testID, testStatus);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Runs the test with invalid inputs and does not update the claim
        /// </summary>
        [TestMethod]
        public void UpdateClaim_InvalidUserID_ReturnsFalse()
        {
            //Arrange
            Claim claim = new Claim();


            int testID = -1; //invalid userID
            ClaimStatus testStatus = ClaimStatus.Approved;

            //Act
            bool result = claim.UpdateClaim(testID, testStatus);

            //Assert
            Assert.IsFalse(result);
        }

    }
}