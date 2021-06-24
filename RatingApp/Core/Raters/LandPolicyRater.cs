using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;

namespace RatingApp.Core.Raters
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(ILogger logger)
            : base(logger)
        {
        }
        public override decimal RatePolicy(Policy policy)
        {
            _logger.LogInformation("Rating LAND policy...");
            _logger.LogInformation("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.LogInformation("Land policy must specify Bond Amount and Valuation.");
                return 0;
            }

            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.LogInformation("Insufficient bond amount.");
                return 0;
            }
            return (policy.BondAmount * 0.05m);
        }
    }
}