using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCardManager
    {
        public int CountOfCards => Cards.Count;
        public IReadOnlyCollection<IRacingCard> Cards { get; set; }

        public RacingCardManager(IRacingCardsFactory racingCardsFactory)
        {        
            Cards = new ReadOnlyCollection<IRacingCard>(racingCardsFactory.Create());
        }
    }
}