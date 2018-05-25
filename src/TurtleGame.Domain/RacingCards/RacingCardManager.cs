using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.RacingCards
{

    public class RacingCardManager : IRacingCardManager
    {
        public double CountOfRacingCardToStart => 7;

        public int CountOfCards => Cards.Count;
        public IReadOnlyCollection<IRacingCard> Cards { get; set; }
        private readonly IEnumerator<IRacingCard> _cardsInDeck;
        public RacingCardManager(IRacingCardsFactory racingCardsFactory, IGenericMixStrategy mixStrategy)
        {
            var listOfRacingCards = racingCardsFactory.Create();
            _cardsInDeck = listOfRacingCards.GetEnumerator();

            Cards = new ReadOnlyCollection<IRacingCard>(mixStrategy.Mix(listOfRacingCards));
        }

        public IRacingCard TakeCard()
        {
            _cardsInDeck.MoveNext();
            return _cardsInDeck.Current;
        }
    }
}