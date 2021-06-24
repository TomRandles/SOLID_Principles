using Moq;
using RatingApp.Core;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using RatingApp.Core.Raters;
using Xunit;

namespace RatingApp.Tests
{
    public class TestRatingEngine
    {
        // private Policy policy = new Policy();

        // Mock logger 
        private Mock<ILogger> mockLogger;
        private Mock<IPolicySource> mockPolicySource;
        private Mock<IPolicySerializer> mockPolicySerialize;
        private Mock<IRaterFactory> mockRaterFactory;

        public TestRatingEngine()
        {
            SetupMockDependencies();
        }

        private void SetupMockDependencies()
        {
            mockLogger = new Mock<ILogger>();

            // Setup string policy from source 
            var policyJson = "{ \"type\": \"Land\", \"bondAmount\": \"1000000\",  \"valuation\": \"1100000\"}";
            mockPolicySource = new Mock<IPolicySource>();
            mockPolicySource.Setup(x => x.GetPolicyFromSource()).Returns(policyJson);

            // Setup corresponding Policy response
            mockPolicySerialize = new Mock<IPolicySerializer>();
            Policy policy;
            mockPolicySerialize.Setup(x => x.GetPolicyFromString(It.IsAny<string>())).
                Returns(policy = new Policy() { Type = PolicyType.Land, BondAmount = 1000000m, Valuation = 1100000m });

            mockRaterFactory = new Mock<IRaterFactory>();
            mockRaterFactory.Setup(x => x.Create(policy)).Returns( new LandPolicyRater(mockLogger.Object));
        }

        [Fact]
        public void TestRatingEngineLandPolicy()
        {
            // Setup ratingEngine

            var ratingEngine = new RatingEngine(mockLogger.Object,
                                                mockPolicySource.Object,
                                                mockPolicySerialize.Object,
                                                mockRaterFactory.Object);

            var expectedResult = 1000000m * 0.05m;
            
            var result = ratingEngine.Rate();

            Assert.Equal(expectedResult, result, 2);
        }
    }
}