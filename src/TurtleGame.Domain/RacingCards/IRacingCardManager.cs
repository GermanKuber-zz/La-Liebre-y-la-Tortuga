using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public interface IRacingCardManager
    {
        int CountOfCards { get; }
        double CountOfRacingCardToStart { get; }
        IRacingCard TakeCard();
        int QuantityOfCardsInDesk { get; }
        void FallCardsToDeck(IRacingCards selectedRacingCardsToFall);
    }
}