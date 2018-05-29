using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.RacingCards
{
    public class RacingCards : IEnumerable<IRacingCard>,IEnumerator<IRacingCard>, IRacingCards
    {
        private readonly IList<IRacingCard> _racingCardsList;

        public IRacingCard this[int index]
        {
            get => _racingCardsList[index];
            set => _racingCardsList.Insert(index, value);
        }

        public int Count => _racingCardsList.Count;
        public static RacingCards Create(IList<IRacingCard> racingCardsList) =>
            new RacingCards(racingCardsList);
        public static RacingCards Create(IReadOnlyCollection<IRacingCard> racingCardsList) =>
            new RacingCards(racingCardsList);

        private RacingCards(IList<IRacingCard> racingCardsList)
        {
            _racingCardsList = racingCardsList;
        }
        private RacingCards(IReadOnlyCollection<IRacingCard> racingCardsList)
        {
            _racingCardsList = racingCardsList.ToList();
        }
        
        public IEnumerator<IRacingCard> GetEnumerator()
        {
            return _racingCardsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            position++;
            return (position < _racingCardsList.Count);
        }

        public void Reset() => position = -1;
        int position = -1;
        public IRacingCard Current
        {
            get
            {
                try
                {
                    return _racingCardsList[position];
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
