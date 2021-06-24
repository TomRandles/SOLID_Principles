using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;
using System;

namespace RatingApp.Core.Raters
{
    public class RaterFactory : IRaterFactory
    {
        private readonly ILogger _logger;
        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }
        public Rater Create(Policy policy)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(_logger);

                case PolicyType.Land:
                    return new LandPolicyRater(_logger);

                case PolicyType.Life:
                    return new LifePolicyRater(_logger);

                default:
                    return new UnknownPolicyRater(_logger);
            }
        }

        public Rater CreateAutomated(Policy policy)
        {
            // Use reflection to automatically find the appropriate class to instantiate
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"RatingApp.Core.Raters.{policy.Type}PolicyRater"),
                    new object[] { _logger });
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }
        }
    }
}