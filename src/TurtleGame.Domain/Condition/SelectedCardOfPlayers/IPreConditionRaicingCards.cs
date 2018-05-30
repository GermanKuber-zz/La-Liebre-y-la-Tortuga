namespace TurtleGame.Domain.RacingCards
{
    public interface IPreConditionRaicingCards
    {
        void SetNext(IPreConditionRaicingCards next);
        bool Validate(IRacingCards racingCards);
    }
}