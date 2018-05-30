using System.Linq;

namespace TurtleGame.Domain.RacingCards
{

    public class PreConditionNoMoreThanFour : PreConditionRaicingCards
    {

        public override bool Validate(IRacingCards racingCards)
        {
            if (racingCards.Count() > 4)
                return false;

            return base.Validate(racingCards);
        }
    }
}