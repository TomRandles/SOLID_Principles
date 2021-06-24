using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using System;

namespace RatingApp.Core.Raters
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger)
            : base(logger)
        {
        }
        public override decimal RatePolicy(Policy policy)
        {
            _logger.LogInformation("Rating AUTO policy...");
            _logger.LogInformation("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.LogInformation("Auto policy must specify Make");
                return 0;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }
            return 0;
        }
    }
}