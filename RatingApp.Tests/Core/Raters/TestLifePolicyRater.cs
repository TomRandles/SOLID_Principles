using Moq;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using RatingApp.Core.Raters;
using System;
using Xunit;

namespace RatingApp.Tests
{
    public class TestLifePolicyRater
    {
        private Policy policy = new Policy();

        // Mock logger 
        private Mock<ILogger> mockLogger;
        private Rater sut;
        public TestLifePolicyRater()
        {
            mockLogger = new Mock<ILogger>();
            sut = new LifePolicyRater(mockLogger.Object);
            policy.Type = PolicyType.Life; 
            policy.IsSmoker = false;
        }

        [Fact]
        public void TestLifeMinimumDateOfBirthPolicy()
        {
            // Setup policy    
            
            policy.DateOfBirth = DateTime.MinValue;
            var result = sut.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestLifeCenturianExclusionPolicy()
        {
            // Setup policy    
            policy.DateOfBirth = DateTime.Today.AddYears(-100);

            var result = sut.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestLifeAmountCannotBeZeroPolicy()
        {
            // Setup policy    
            policy.DateOfBirth = DateTime.Today.AddYears(-99);
            policy.Amount = 0m;

            var result = sut.RatePolicy(policy);

            Assert.Equal(0m, result, 0);
        }

        [Fact]
        public void TestLifeNonSmokerRatePolicy()
        {
            // Setup policy    
            policy.DateOfBirth = DateTime.Today.AddYears(-99);
            policy.Amount = 1000m;
            policy.IsSmoker = false;

            var expectedResult = policy.Amount * 99 / 200;
            var result = sut.RatePolicy(policy);

            Assert.Equal(expectedResult, result, 0);
        }

        [Fact]
        public void TestLifeSmokerRatePolicy()
        {
            // Setup policy    
            policy.DateOfBirth = DateTime.Today.AddYears(-99);
            policy.Amount = 1000m;
            policy.IsSmoker = true;

            var expectedResult = ((policy.Amount * 99 / 200) * 2);
            var result = sut.RatePolicy(policy);

            Assert.Equal(expectedResult, result, 0);
        }
    }
}