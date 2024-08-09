using TestNinja.FundamentalsIgnored;

namespace TestProject1
{
    [TestClass]
    public class CalculateDemeritPointsTest
    {
        private const int SpeedLimit = 65;
        private const int MaxSpeed = 300;
        private const int kmPerDemeritPoint = 5;
        private DemeritPointsCalculator dpc = new DemeritPointsCalculator();
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateDemeritPoints_WhenSpeedIsUnder0_ReturnOutOfRangeException()
        {
            int speed = -1;

            dpc.CalculateDemeritPoints(speed);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateDemeritPoints_WhenSpeedIsOverMax_ReturnOutOfRangeException()
        {
            int speed = 361;

            dpc.CalculateDemeritPoints(speed);
        }

        [TestMethod]
        public void CalculateDemeritPoints_WhenSpeedIsGreaterThanLimit_ReturnOutOfRangeException()
        {
            int speed = 70;

           int demerit = dpc.CalculateDemeritPoints(speed);

            Assert.IsTrue(demerit > 0);
        }

        [TestMethod]
        public void CalculateDemeritPoints_WhenSpeedIsUnderLimit_ReturnOutOfRangeException()
        {
            int speed = 55;

            int demerit = dpc.CalculateDemeritPoints(speed);

            Assert.IsTrue(demerit == 0);
        }
    }
}
