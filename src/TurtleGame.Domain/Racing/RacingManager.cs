using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Racing
{
    public class RacingManager
    {
        private readonly IRacingCardOnDeskManager _racingCardOnDeskManager;

        public RacingManager(IRacingCardOnDeskManager racingCardOnDeskManager)
        {
            _racingCardOnDeskManager = racingCardOnDeskManager;
        }

        public void StartRace()
        {
            var cardsInDesk = _racingCardOnDeskManager.TakeAllDesktCard();
            var group = cardsInDesk.GroupBy(x => x.GetType());

            group.ToList().ForEach(x =>
            {
                var cardsToFall = x.ToList();
                //Raise Domain Event, With the list of the cards, need to Use MediatR
                //Fall the group of the cards, with the same animals, to the desktop again
                _racingCardOnDeskManager.FallCardsToDeck(RacingCards.RacingCards.Create(cardsToFall));
            });
        }
    }
}
