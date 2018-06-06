using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Types;

namespace TurtleGame.Domain.RacingCards.Factories
{
    public class RacingCardsFactory : IRacingCardsFactory
    {
        private List<IRacingCard> _racingCards;

        public List<IRacingCard> Create()
        {
            if (_racingCards == null)
            {
                _racingCards = new List<IRacingCard>();
                _racingCards.AddRange(Enumerable.Range(1, 18).Select(x => new HareRacingCard()));
                _racingCards.AddRange(Enumerable.Range(1, 17).Select(x => new TurtleRacingCard()));
                _racingCards.AddRange(Enumerable.Range(1, 16).Select(x => new WolfRacingCard()));
                _racingCards.AddRange(Enumerable.Range(1, 15).Select(x => new FoxRacingCard()));
                _racingCards.AddRange(Enumerable.Range(1, 15).Select(x => new LambRacingCard()));
                //_racingCards.AddRange(Enumerable.Range(1, 20).Select(x => new HareRacingCard()));
 

                return _racingCards;
            }
            else
                return _racingCards;
        }
    }
}