using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCardManager
    {
        public int CountOfCards => Cards.Count;
        public IReadOnlyCollection<IRacingCard> Cards { get; set; }

        public RacingCardManager(IRacingCardsFactory racingCardsFactory, IGenericMixStrategy mixStrategy)
        {
            Cards = new ReadOnlyCollection<IRacingCard>(mixStrategy.Mix(racingCardsFactory.Create()));
        }
    }
}