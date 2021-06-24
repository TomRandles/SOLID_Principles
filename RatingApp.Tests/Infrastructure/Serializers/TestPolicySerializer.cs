using RatingApp.Core.Models;
using RatingApp.Infrastructure.Serializers;
using Xunit;

namespace RatingApp.Tests.Infrastructure.Serializers
{
    public class TestPolicySerializer
    {
        [Fact]
        public void TestDefaultPolicySerializer()
        {
            var expectedPolicy = new Policy();

            var policyJson = "{}";

            var sut = new JsonPolicySerializer();

            var result = sut.GetPolicyFromString(policyJson);
            AssertPoliciesAreEqual(expectedPolicy, result);
        }

        [Fact]
        public void TestJsonPolicySerializerLandPolicy()
        {
            var expectedPolicy = new Policy();
            expectedPolicy.Type = PolicyType.Land;
            expectedPolicy.BondAmount = 1000000m;
            expectedPolicy.Valuation = 1100000m;

            var policyJson = 
                "{ \"type\": \"Land\", \"bondAmount\": \"1000000\",  \"valuation\": \"1100000\"}";

            var sut = new JsonPolicySerializer();

            var result = sut.GetPolicyFromString(policyJson);

            Assert.Equal(expectedPolicy.Type, result.Type);
            Assert.Equal(expectedPolicy.BondAmount, result.BondAmount, 2);
            Assert.Equal(expectedPolicy.Valuation, result.Valuation, 2);
        }

        [Fact]
        public void TestJsonPolicySerializerAutoPolicy()
        {
            var expectedPolicy = new Policy();
            expectedPolicy.Type = PolicyType.Auto;
            expectedPolicy.Make = "Volvo";
           

            var policyJson =
                "{ \"type\": \"Auto\", \"Make\": \"Volvo\" }";

            var sut = new JsonPolicySerializer();

            var result = sut.GetPolicyFromString(policyJson);

            Assert.Equal(expectedPolicy.Type, result.Type);
            Assert.Equal(expectedPolicy.Make, result.Make);
        }

        private void AssertPoliciesAreEqual(Policy expectedPolicy, Policy result)
        {
            Assert.Equal(expectedPolicy.Address, result.Address);
            Assert.Equal(expectedPolicy.Amount, result.Amount);
            Assert.Equal(expectedPolicy.BondAmount, result.BondAmount);
            Assert.Equal(expectedPolicy.DateOfBirth, result.DateOfBirth);
            Assert.Equal(expectedPolicy.Deductible, result.Deductible);
            Assert.Equal(expectedPolicy.FullName, result.FullName);
            Assert.Equal(expectedPolicy.IsSmoker, result.IsSmoker);
            Assert.Equal(expectedPolicy.Make, result.Make);
            Assert.Equal(expectedPolicy.Miles, result.Miles);
            Assert.Equal(expectedPolicy.Model, result.Model);
            Assert.Equal(expectedPolicy.Type, result.Type);
            Assert.Equal(expectedPolicy.Valuation, result.Valuation);
            Assert.Equal(expectedPolicy.Year, result.Year);
        }
    }
}
