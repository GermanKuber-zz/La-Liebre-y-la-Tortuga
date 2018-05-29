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
        private readonly IRacingCards _cardsInDeck;
        public RacingCardManager(IRacingCardsFactory racingCardsFactory, IGenericMixStrategy mixStrategy)
        {
            var listOfRacingCards = racingCardsFactory.Create();
            _cardsInDeck = RacingCards.Create(listOfRacingCards);

            Cards = RacingCards.Create(mixStrategy.Mix(listOfRacingCards));
        }

        public IRacingCard TakeCard()
        {
            Cards.MoveNext();
            return Cards.Current;
        }
    }
}