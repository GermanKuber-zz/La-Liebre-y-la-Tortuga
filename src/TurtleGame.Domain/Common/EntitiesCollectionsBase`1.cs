using System;
using System.Collections.Generic;
using System.Linq;

namespace TurtleGame.Domain.Common
{
    public class EntitiesCollectionsBase<TEntity> : EnumeratorBase<TEntity>, IEntitiesCollectionsBase<TEntity>
    {
        protected EntitiesCollectionsBase(List<TEntity> entitiesList) : base(entitiesList)
        {
        }
        public TEntity GiveMeNextTo(TEntity previousEntity)
        {
            var enumerator = EntitiesList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Equals(previousEntity))
                {
                    if (enumerator.MoveNext())
                        return enumerator.Current;
                    break;
                }
            }
            return EntitiesList.First();
        }
        public List<TEntity> Clear()
        {
            var returnList = new List<TEntity>();

            EntitiesList.ToList()
                           .ForEach(x =>
                           {
                               returnList.Add(x);
                           });
            EntitiesList.Clear();
            return returnList;
        }
        public void Add(TEntity entityCard) => EntitiesList.Add(entityCard);
        public void Add(IList<TEntity> entityCards) => EntitiesList.AddRange(entityCards);
        public void Remove(TEntity entityCard) => EntitiesList.Remove(entityCard);
        public TEntity First() => EntitiesList.First();
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