using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Types;

namespace TurtleGame.Domain.RacingCards.Factories
{
    public class RacingCardsFactory : IRacingCardsFactory
    {
        public List<IRacingCard> Create()
        {
            List<IRacingCard> racingCards = new List<IRacingCard>();
            racingCards.AddRange(Enumerable.Range(1, 18).Select(x => new HareRacingCard()));
            racingCards.AddRange(Enumerable.Range(1, 17).Select(x => new TurtleRacingCard()));
            racingCards.AddRange(Enumerable.Range(1, 16).Select(x => new WolfRacingCard()));
            racingCards.AddRange(Enumerable.Range(1, 15).Select(x => new FoxRacingCard()));
            racingCards.AddRange(Enumerable.Range(1, 15).Select(x => new LambRacingCard()));
            return racingCards;
        }
    }
}