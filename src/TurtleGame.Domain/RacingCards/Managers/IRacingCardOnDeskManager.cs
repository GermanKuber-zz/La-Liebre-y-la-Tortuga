using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards.Managers
{
    public interface IRacingCardOnDeskManager: IMixDiscartCards
    {
        int QuantityOfCardsToPlay { get; }
        bool FallCardsToDeck(IRacingCards racingCard);
        bool IsValid();
        IEnumerable<IRacingCard> TakeAllDesktCard();
    }
    public interface IMixDiscartCards
    {
        IEnumerable<IRacingCard> MixAll();
    }
}