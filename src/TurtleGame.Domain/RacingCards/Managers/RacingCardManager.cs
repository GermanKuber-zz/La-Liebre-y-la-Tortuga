using System;
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
        public int CountOfCards => _cards.Count();
        public IRacingCards _cards;

        private readonly IMixDiscartCards _mixDiscartCards;

        public RacingCardManager(IRacingCardsFactory racingCardsFactory,
            IGenericMixStrategy mixStrategy,
            IMixDiscartCards mixDiscartCards)
        {
            var listOfRacingCards = racingCardsFactory.Create();

            _cards = RacingCards.Create(mixStrategy.Mix(listOfRacingCards));
            _mixDiscartCards = mixDiscartCards;
        }
        public IRacingCard TakeCard()
        {
            var item = _cards.FirstOrDefault();
            if (item != null)
            {
                _cards.Remove(item);
                return item;
            }
            else
            {
                var cardsToAdd = _mixDiscartCards.MixAll().ToList();
                //TODO: Remove null posibility
                if (cardsToAdd.Count() == 0)
                    throw new ApplicationException();
                _cards.Add(cardsToAdd);
                var itemToReturn = _cards.FirstOrDefault();
                _cards.Remove(itemToReturn);
                return itemToReturn;
            }
        }
    }
}