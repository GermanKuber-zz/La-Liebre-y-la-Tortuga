using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public interface IRacingCardOnDeskManager: IMixDiscartCards
    {
        int QuantityOfCardsToPlay { get; }
        bool FallCardsToDeck(IRacingCards racingCard);
        bool IsValid();
    }
    public interface IMixDiscartCards
    {
        IEnumerable<IRacingCard> MixAll();
    }
}