using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurtleGame.Domain.Events;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Managers;
using TurtleGame.Domain.Tracks;

namespace TurtleGame.Domain.Racing
{
    public class RacingManager
    {
        private readonly IRacingCardOnDeskManager _racingCardOnDeskManager;
        private readonly ITrackManager _trackManager;

        public RacingManager(IRacingCardOnDeskManager racingCardOnDeskManager,
                             ITrackManager trackManager)
        {
            _racingCardOnDeskManager = racingCardOnDeskManager;
            _trackManager = trackManager;
        }

        public void StartRace()
        {
            var cardsInDesk = _racingCardOnDeskManager.TakeAllDesktCard();
            var group = cardsInDesk.GroupBy(x => x.GetType());

            group.ToList().ForEach(x =>
            {
                var cardsToFall = RacingCards.RacingCards.Create(x.ToList());

                //Raise Domain Event, With the list of the cards, need to Use MediatR
                //Fall the group of the cards, with the same animals, to the desktop again
                _racingCardOnDeskManager.FallCardsToDeck(cardsToFall);
            });
        }
    }
}
