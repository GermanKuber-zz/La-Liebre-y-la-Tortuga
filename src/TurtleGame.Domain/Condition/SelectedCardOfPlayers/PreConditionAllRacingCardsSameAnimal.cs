using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Condition.SelectedCardOfPlayers
{
    public class PreConditionAllRacingCardsSameAnimal : PreConditionRaicingCards
    {
        public PreConditionAllRacingCardsSameAnimal(IPreConditionRaicingCards next) : base(next)
        {

        }

        public PreConditionAllRacingCardsSameAnimal() : base()
        {

        }
        public override bool Validate(IRacingCards racingCards)
        {
            if (!racingCards.AllCardAreTheSameAnimal())
                return false;

            return base.Validate(racingCards);
        }
    }
}