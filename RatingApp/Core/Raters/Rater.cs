using RatingApp.Core.Interfaces;
using RatingApp.Core.Models;

namespace RatingApp.Core.Raters
{
    public abstract class Rater
    {
        protected readonly ILogger _logger;

        public Rater(ILogger logger)
        {
            _logger = logger;
        }
        public abstract decimal RatePolicy(Policy policy);
    }
}