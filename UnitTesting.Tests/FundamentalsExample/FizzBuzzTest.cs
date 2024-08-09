using TestNinja.Fundamentals;

namespace UnitTesting.Tests.Fundamentals
{
    [TestClass]
    public class FizzBuzzTest
    {

        [TestMethod]
        public void GetOutput_WhenModulo3IsZero_ReturnsFizz()
        {
            //Arrange
            string fizz = "Fizz";
            int input = 9;

            // Act
            string output = FizzBuzz.GetOutput(input);

            // Assert
            Assert.IsTrue(output.Contains(fizz));
        }


    }
}