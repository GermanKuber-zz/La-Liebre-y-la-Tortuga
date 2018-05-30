using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.RacingCards
{

    public class RacingCardManager : IRacingCardManager
    {
        public double CountOfRacingCardToStart => 7;

        public int CountOfCards => Cards.Count();
        public IRacingCards Cards { get; set; }
        public int QuantityOfCardsInDesk => _cardsInDeck.Count();

        private readonly IRacingCards _cardsInDeck;
        public RacingCardManager(IRacingCardsFactory racingCardsFactory, IGenericMixStrategy mixStrategy)
        {
            var listOfRacingCards = racingCardsFactory.Create();
            _cardsInDeck = RacingCards.Create(new List<IRacingCard>());

            Cards = RacingCards.Create(mixStrategy.Mix(listOfRacingCards));
        }

        public IRacingCard TakeCard()
        {
            Cards.MoveNext();
            return Cards.Current;
        }
        public void FallCardsToDeck(IRacingCards selectedRacingCardsToFall) {
            selectedRacingCardsToFall.Each(x => _cardsInDeck.Add(x));
        }
    }
}