using Moq;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using RatingApp.Core.Raters;
using Xunit;

namespace RatingApp.Tests
{
    public class TestRaterFactory
    {
        private Policy policy = new Policy();

        // Mock logger 
        private Mock<ILogger> mockLogger;
        private RaterFactory raterFactory;
        public TestRaterFactory()
        {
            mockLogger = new Mock<ILogger>();
            raterFactory = new RaterFactory(mockLogger.Object);
        }

        [Fact]
        public void TestLifePolicyGeneration()
        {
            // Setup policy    
            policy.Type = PolicyType.Life;

            var result = raterFactory.Create(policy);

            Assert.Equal(typeof(LifePolicyRater), result.GetType());
        }

        [Fact]
        public void TestLandPolicyGeneration()
        {
            // Setup policy    
            policy.Type = PolicyType.Land;

            var result = raterFactory.Create(policy);

            Assert.Equal(typeof(LandPolicyRater), result.GetType());
        }

        [Fact]
        public void TestAutoPolicyGeneration()
        {
            // Setup policy    
            policy.Type = PolicyType.Auto;

            var result = raterFactory.Create(policy);

            Assert.Equal(typeof(AutoPolicyRater), result.GetType());
        }

        [Fact]
        public void TestUnknownPolicyGeneration()
        {
            // Setup policy    
            policy.Type = (PolicyType)8;

            var result = raterFactory.Create(policy);

            Assert.Equal(typeof(UnknownPolicyRater), result.GetType());
        }

        [Fact]
        public void TestAutoPolicyAutomatedGeneration()
        {
            // Setup policy    
            policy.Type = PolicyType.Auto;

            var result = raterFactory.CreateAutomated(policy);

            Assert.Equal(typeof(AutoPolicyRater), result.GetType());
        }

        [Fact]
        public void TestLifePolicyAutomatedGeneration()
        {
            // Setup policy    
            policy.Type = PolicyType.Life;

            var result = raterFactory.CreateAutomated(policy);

            Assert.Equal(typeof(LifePolicyRater), result.GetType());
        }

        [Fact]
        public void TestLandPolicyAutomatedGeneration()
        {
            // Setup policy    
            policy.Type = PolicyType.Land;

            var result = raterFactory.CreateAutomated(policy);

            Assert.Equal(typeof(LandPolicyRater), result.GetType());
        }

        [Fact]
        public void TestUnknownPolicyAutomatedGeneration()
        {
            // Setup policy    
            policy.Type = (PolicyType)8;

            var result = raterFactory.CreateAutomated(policy);

            Assert.Equal(typeof(UnknownPolicyRater), result.GetType());
        }
    }
}