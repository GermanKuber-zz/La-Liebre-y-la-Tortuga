using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Condition.SelectedCardOfPlayers
{
    public interface IPreConditionRaicingCards
    {
        void SetNext(IPreConditionRaicingCards next);
        bool Validate(IRacingCards racingCards);
    }
}