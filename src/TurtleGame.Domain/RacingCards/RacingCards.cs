using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Common;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCards : EntitiesCollectionsBase<IRacingCard>, IRacingCards
    {
        public static RacingCards Create(List<IRacingCard> racingCardsList) =>
            new RacingCards(racingCardsList);
        public static RacingCards Create(IReadOnlyCollection<IRacingCard> racingCardsList) =>
            new RacingCards(racingCardsList);



        private RacingCards(List<IRacingCard> racingCardsList) : base(racingCardsList)
        {
        }
        private RacingCards(IReadOnlyCollection<IRacingCard> racingCardsList) : base(racingCardsList.ToList())
        {
        }

        public bool AllCardAreTheSameAnimal() => EntitiesList.GroupBy(x => x.GetType())
                                                             .Count() == 1;


        

    }
}
