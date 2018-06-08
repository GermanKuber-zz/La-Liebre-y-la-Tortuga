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

            group.ToList().ForEach(x => _racingCardOnDeskManager
                                        .FallCardsToDeck(RacingCards.RacingCards.Create(x.ToList())));
        }
    }
}
