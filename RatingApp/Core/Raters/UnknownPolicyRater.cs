using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;

namespace RatingApp.Core.Raters
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger) 
            : base (logger)
        {
        }
        public override decimal RatePolicy(Policy policy)
        {
            _logger.LogInformation("Unknown policy type");
            return 0;
        }
    }
}