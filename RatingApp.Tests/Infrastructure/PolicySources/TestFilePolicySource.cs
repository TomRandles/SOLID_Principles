using Moq;
using Newtonsoft.Json.Linq;
using RatingApp.Core.Interfaces;
using RatingApp.Infrastructure.PolicySources;
using System.Text.RegularExpressions;
using Xunit;

namespace RatingApp.Tests.Infrastructure.Serializers
{
    public class TestFilePolicySource
    {

        [Fact]
        public void TestDefaultFilePolicySource()
        {
            var expectedPolicyJson =
                "{ \"type\": \"Land\", \"bondAmount\": \"1000000\", \"valuation\": \"1100000\"}";

            // Create mock FilePolicySource 
            // Mock<IPolicySource> mockFilePolicySource = new Mock<IPolicySource>();
            // mockFilePolicySource.Setup(x => x.GetPolicyFromSource()).Returns

            var sut = new FilePolicySource();

            var result = sut.GetPolicyFromSource();

            // cleanup
            Regex reg = new Regex("[\r\n]");
            var myCleanJsonResult = reg.Replace(result, string.Empty);

            Regex reg2 = new Regex("  ");
            var myCleanJsonResult2 = reg2.Replace(myCleanJsonResult, " ");

            Assert.Equal(expectedPolicyJson, myCleanJsonResult2);
        }
    }
}