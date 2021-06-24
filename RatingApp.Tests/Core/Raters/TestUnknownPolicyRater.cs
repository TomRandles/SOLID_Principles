using Moq;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using RatingApp.Core.Raters;
using Xunit;

namespace RatingApp.Tests
{
    public class TestUnknownPolicyRater
    {
        private Policy policy = new Policy();

        // Mock logger 
        private Mock<ILogger> mockLogger;
        private Rater rater;
        public TestUnknownPolicyRater()
        {
            mockLogger = new Mock<ILogger>();
            rater = new UnknownPolicyRater(mockLogger.Object);
            policy.Type = (PolicyType)8; // unknown policy
        }

        [Fact]
        public void TestUnknownPolicyType()
        {
            var result = rater.RatePolicy(policy);
            Assert.Equal(0m, result, 0);
        }
    }
}