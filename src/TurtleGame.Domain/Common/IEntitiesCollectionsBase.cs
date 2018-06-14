using System;
using System.Collections.Generic;

namespace TurtleGame.Domain.Common
{
    public interface IEntitiesCollectionsBase<TEntity>
    {
        void Add(TEntity entityCard);
        TEntity First();
        List<TEntity> Clear();
        void Add(IList<TEntity> entityCards);
        void Each(Action<TEntity, int> eachCallBack, int quantityOfEach);
        void Each(Action<TEntity> eachCallBack);
        void Each(Action<TEntity> eachCallBack, int quantityOfEach);
        void Remove(TEntity entityCard);
    }
}