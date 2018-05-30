using System;
using System.Collections;
using System.Collections.Generic;

namespace TurtleGame.Domain.RacingCards
{
    public class EntitiesCollectionsBase<TEntity> : EnumeratorBase<TEntity>
    {
        protected EntitiesCollectionsBase(List<TEntity> entitiesList):base(entitiesList)
        {
        }
        public void Add(TEntity entityCard) => EntitiesList.Add(entityCard);
        public void Remove(TEntity entityCard) => EntitiesList.Remove(entityCard);
    }

    public class EnumeratorBase<TEntity> : IEnumerable<TEntity>, IEnumerator<TEntity>
    {
        protected readonly List<TEntity> EntitiesList;
        int _position = -1;

        protected EnumeratorBase(List<TEntity> entitiesList)
        {
            EntitiesList = entitiesList;
        }

        public IEnumerator<TEntity> GetEnumerator() => EntitiesList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool MoveNext()
        {
            _position++;
            return (_position < EntitiesList.Count);
        }

        public void Reset() => _position = -1;



        public TEntity Current
        {
            get
            {
                try
                {
                    return EntitiesList[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}