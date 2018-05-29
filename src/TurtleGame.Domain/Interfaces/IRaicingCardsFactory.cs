using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IRaicingCardsFactory
    {
        List<IRacingCard> Create();
    }
}