using RatingApp.Core.Interfaces;
using System.IO;

namespace RatingApp.Infrastructure.PolicySources
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}