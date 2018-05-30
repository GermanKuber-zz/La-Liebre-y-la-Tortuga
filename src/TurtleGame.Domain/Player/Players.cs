using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public class Players : EntitiesCollectionsBase<IPlayer>, IPlayers
    {

        public Players(IEnumerable<IPlayer> players) : base(players.ToList())
        {
        }

        public void Each(Action<IPlayer> eachCallBack) => EntitiesList.ForEach(eachCallBack);
        public void Each(Action<IPlayer> eachCallBack, int quantityOfEach)
        {
            if (quantityOfEach <= 0 || quantityOfEach >= 15)
                throw new ArgumentException(nameof(quantityOfEach));

            Enumerable.Range(0, quantityOfEach)
                .ToList()
                .ForEach(x => this.Each(eachCallBack));
        }

        public void Each(Action<IPlayer, int> eachCallBack, int quantityOfEach)
        {
            if (quantityOfEach <= 0 || quantityOfEach >= 15)
                throw new ArgumentException(nameof(quantityOfEach));

            var index = 0;
            Enumerable.Range(0, quantityOfEach)
                .ToList()
                .ForEach(x =>
                {
                    EntitiesList.ForEach(p =>
                    {
                        eachCallBack(p, index);
                        ++index;
                    });
                });
        }

        public new IEnumerator<IPlayers> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IPlayers Current => this.Current;
    }
}