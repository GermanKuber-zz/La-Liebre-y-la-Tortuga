using System;
using System.Collections.Generic;
using TurtleGame.Domain.Common;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Player
{
    public interface IPlayers : ICollectionsBase<IPlayer>
    {
        IPlayer GiveMeNextTo(IPlayer currentFirstPlayer);
    }
    public interface ICollectionsBase<TEntity> : IEntitiesCollectionsBase<TEntity>, IEnumerable<TEntity>, IEnumerator<TEntity>
    {
        void Each(Action<TEntity> eachCallBack);
        void Each(Action<TEntity> eachCallBack, int quantityOfEach);
        void Each(Action<TEntity, int> eachCallBack, int quantityOfEach);
    }
}