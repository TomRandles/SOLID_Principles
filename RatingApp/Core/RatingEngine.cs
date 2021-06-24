using RatingApp.Core.Interfaces;

namespace RatingApp.Core
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly IRaterFactory _raterFactory;
        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger,
                            IPolicySource policySource,
                            IPolicySerializer policySerializer,
                            IRaterFactory raterFactory)
        {
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }
        public decimal Rate()
        {
            _logger.LogInformation("Starting rate.");

            _logger.LogInformation("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromString(policyJson);

            var rater = _raterFactory.Create(policy);
 
            var result = rater.RatePolicy(policy);

            _logger.LogInformation("Rating completed.");
            return result;
        }
    }
}