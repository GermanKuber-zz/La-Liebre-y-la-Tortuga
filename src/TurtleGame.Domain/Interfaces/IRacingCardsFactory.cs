using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IRacingCardsFactory
    {
        List<IRacingCard> Create();
    }
}