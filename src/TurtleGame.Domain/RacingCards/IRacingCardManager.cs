using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public interface IRacingCardManager
    {
        IReadOnlyCollection<IRacingCard> Cards { get; set; }
        int CountOfCards { get; }
        double CountOfRacingCardToStart { get; }
        IRacingCard TakeCard();
    }
}