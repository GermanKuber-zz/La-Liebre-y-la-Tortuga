using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.RacingCards.Types;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCardManager
    {
        private readonly List<IRacingCard> _racingCards = new List<IRacingCard>();
        public int CountOfCards => _racingCards.Count;
        public IReadOnlyCollection<IRacingCard> Cards { get; set; }

        public RacingCardManager()
        {
            _racingCards.AddRange(Enumerable.Range(1, 18).Select(x => new HareRacingCard()));
            _racingCards.AddRange(Enumerable.Range(1, 17).Select(x => new TurtleRacingCard()));
            _racingCards.AddRange(Enumerable.Range(1, 16).Select(x => new WolfRacingCard()));
            _racingCards.AddRange(Enumerable.Range(1, 15).Select(x => new FoxRacingCard()));
            _racingCards.AddRange(Enumerable.Range(1, 15).Select(x => new LambRacingCard()));
            Cards = new ReadOnlyCollection<IRacingCard>(_racingCards);
        }
    }
}