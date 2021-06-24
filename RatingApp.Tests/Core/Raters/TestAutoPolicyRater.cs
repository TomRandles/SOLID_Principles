using Moq;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using RatingApp.Core.Raters;
using Xunit;

namespace RatingApp.Tests
{
    public class TestAutoPolicyRater
    {
        private Policy policy = new Policy();

        // Mock logger 
        private Mock<ILogger> mockLogger;
        private Rater rater;
        public TestAutoPolicyRater()
        {
            mockLogger = new Mock<ILogger>();
            rater = new AutoPolicyRater(mockLogger.Object);
        }

        [Fact]
        public void TestAutoBMWDeductablePolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Auto;
            policy.Make = "BMW";
            policy.Deductible = 499m;

            var result = rater.RatePolicy(policy);

            Assert.Equal(1000m, result, 0);
        }

        [Fact]
        public void TestAutoBMWNonDeductablePolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Auto;
            policy.Make = "BMW";
            policy.Deductible = 500m; // Test boundary

            var result = rater.RatePolicy(policy);

            Assert.Equal(900m, result, 0);
        }

        [Fact]
        public void TestAutoNonBMWPolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Auto;
            policy.Make = "Volvo";

            var result = rater.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestAutoNoMakeSetPolicy()
        {
            // Setup policy    
            policy.Type = PolicyType.Auto;
            policy.Make = default;

            var result = rater.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }
    }
}