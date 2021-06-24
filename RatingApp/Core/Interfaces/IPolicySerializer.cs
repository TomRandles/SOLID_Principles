using RatingApp.Core.Models;

namespace RatingApp.Core.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}