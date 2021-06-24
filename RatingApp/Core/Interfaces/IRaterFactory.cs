using RatingApp.Core.Models;
using RatingApp.Core.Raters;

namespace RatingApp.Core.Interfaces
{
    public interface IRaterFactory
    {
        Rater Create(Policy policy);
        Rater CreateAutomated(Policy policy);
    }
}