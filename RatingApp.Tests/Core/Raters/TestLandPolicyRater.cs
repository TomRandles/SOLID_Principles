using Moq;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using RatingApp.Core.Raters;
using Xunit;

namespace RatingApp.Tests
{
    public class TestLandPolicyRater
    {
        private Policy policy = new Policy();

        // Mock logger 
        private Mock<ILogger> mockLogger;
        private Rater rater;
        public TestLandPolicyRater()
        {
            mockLogger = new Mock<ILogger>();
            rater = new LandPolicyRater(mockLogger.Object);
        }

        [Fact]
        public void TestLandZeroBondAmountPolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Land;
            policy.BondAmount = 0m;
            
            var result = rater.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestLandZeroValuationAmountPolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Land;
            policy.Valuation = 0m;

            var result = rater.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestLandInsufficentBondAmountPolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Land;
            policy.Valuation = 1000m; 
            policy.BondAmount = 0.79m * policy.Valuation;
            
            var result = rater.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestLandExpectedRatePolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Land;
            policy.Valuation = 1000m;
            policy.BondAmount = 0.80m * policy.Valuation;

            var expectedResult = policy.BondAmount * 0.05m;

            var result = rater.RatePolicy(policy);

            Assert.Equal(expectedResult, result, 0);
        }
    }
}