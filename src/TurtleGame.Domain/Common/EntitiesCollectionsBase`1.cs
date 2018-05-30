using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TurtleGame.Domain.RacingCards
{
    public class EntitiesCollectionsBase<TEntity> : EnumeratorBase<TEntity>, IEntitiesCollectionsBase<TEntity>
    {
        protected EntitiesCollectionsBase(List<TEntity> entitiesList) : base(entitiesList)
        {
        }
        public void Add(TEntity entityCard) => EntitiesList.Add(entityCard);
        public void Remove(TEntity entityCard) => EntitiesList.Remove(entityCard);

        public void Each(Action<TEntity> eachCallBack) => EntitiesList.ForEach(eachCallBack);
        public void Each(Action<TEntity> eachCallBack, int quantityOfEach)
        {
            if (quantityOfEach <= 0 || quantityOfEach >= 15)
                throw new ArgumentException(nameof(quantityOfEach));

            Enumerable.Range(0, quantityOfEach)
                .ToList()
                .ForEach(x => this.Each(eachCallBack));
        }

        public void Each(Action<TEntity, int> eachCallBack, int quantityOfEach)
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
    }
}