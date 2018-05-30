using System;
using System.Collections.Generic;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public interface IPlayers : ICollectionsBase<IPlayer>
    {
    }
    public interface ICollectionsBase<TEntity> : IEntitiesCollectionsBase<TEntity>,IEnumerable<TEntity>, IEnumerator<TEntity>
    {
        void Each(Action<TEntity> eachCallBack);
        void Each(Action<TEntity> eachCallBack, int quantityOfEach);
        void Each(Action<TEntity, int> eachCallBack, int quantityOfEach);
    }
}