using TurtleGame.Domain.Common;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCardBase<TRacindCard> : ValueObject<TRacindCard>
                                               where TRacindCard : ValueObject<TRacindCard>,
                                               IRacingCard
    {
        protected override bool EqualsCore(TRacindCard other)
        {
            return true;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = this.GetHashCode();
                return hashCode;
            }
        }
    }
}
