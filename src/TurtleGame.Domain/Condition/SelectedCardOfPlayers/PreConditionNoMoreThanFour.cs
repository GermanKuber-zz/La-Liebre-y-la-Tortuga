using System.Linq;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Condition.SelectedCardOfPlayers
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