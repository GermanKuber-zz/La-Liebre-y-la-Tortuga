using TurtleGame.Domain.Condition.SelectedCardOfPlayers;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Condition.Factories
{
    public class PreConditionRaicingCardsFactory : IPreConditionRaicingCardsFactory
    {
        public IPreConditionRaicingCards Create() => new PreConditionAllRacingCardsSameAnimal(new PreConditionNoMoreThanFour());
    }
}
