using System;

namespace TurtleGame.Domain.RacingCards
{
    public interface IEntitiesCollectionsBase<TEntity>
    {
        void Add(TEntity entityCard);
        TEntity First();
        void Each(Action<TEntity, int> eachCallBack, int quantityOfEach);
        void Each(Action<TEntity> eachCallBack);
        void Each(Action<TEntity> eachCallBack, int quantityOfEach);
        void Remove(TEntity entityCard);
    }
}