using System.Collections.Generic;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public interface IRacingCards: IEnumerable<IRacingCard>, IEnumerator<IRacingCard>
    {
    }
}