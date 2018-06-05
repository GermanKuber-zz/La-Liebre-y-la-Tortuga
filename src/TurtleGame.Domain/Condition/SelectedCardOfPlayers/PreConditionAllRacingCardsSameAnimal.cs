using System.Linq;

namespace TurtleGame.Domain.RacingCards
{
    public class PreConditionAllRacingCardsSameAnimal : PreConditionRaicingCards
    {
 
        public override bool Validate(IRacingCards racingCards)
        {
            if (!racingCards.AllCardAreTheSameAnimal())
                return false;

            return base.Validate(racingCards);
        }
    }
}