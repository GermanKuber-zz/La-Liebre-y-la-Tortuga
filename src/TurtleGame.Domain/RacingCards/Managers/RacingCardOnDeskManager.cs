using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCardOnDeskManager : IRacingCardOnDeskManager
    {
        private readonly IRacingCards _cardsInDeck = RacingCards.Create(new List<IRacingCard>());
        public bool IsValid() => _cardsInDeck.Count() != 8;
        public int QuantityOfCards => _cardsInDeck.Count();
        public bool FallCardsToDeck(IRacingCards racingCard)
        {
            racingCard.ToList().ForEach(x => _cardsInDeck.Add(x));
            return true;
        }

        public IEnumerable<IRacingCard> MixAll() => _cardsInDeck.Clear();
    }
}