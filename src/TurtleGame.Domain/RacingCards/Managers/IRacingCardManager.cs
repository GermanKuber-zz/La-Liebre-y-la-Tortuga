using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards.Managers
{
    public interface IRacingCardManager
    {
        int CountOfCards { get; }
        double CountOfRacingCardToStart { get; }
        IRacingCard TakeCard();
      
    }
}