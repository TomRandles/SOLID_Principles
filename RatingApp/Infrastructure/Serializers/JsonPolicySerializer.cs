using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;

namespace RatingApp.Infrastructure.Serializers
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string jsonInput)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonInput,
                new StringEnumConverter());
        }

        Policy IPolicySerializer.GetPolicyFromString(string policyString)
        {
            throw new System.NotImplementedException();
        }
    }
}