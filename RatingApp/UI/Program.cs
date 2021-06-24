using RatingApp.Core;
using RatingApp.Core.Raters;
using RatingApp.Infrastructure.Loggers;
using RatingApp.Infrastructure.PolicySources;
using RatingApp.Infrastructure.Serializers;
using System;

namespace RatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Rating System Starting...");

            // No IoC Container service available - instantiate the required objects here. 
            var logger = new FileLogger();

            var engine = new RatingEngine(logger,
                                          new FilePolicySource(),
                                          new JsonPolicySerializer(),
                                          new RaterFactory(logger));

            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }
        }
    }
}
