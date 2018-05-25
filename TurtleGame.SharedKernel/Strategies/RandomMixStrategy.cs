using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.SharedKernel.Strategies
{
    public class RandomMixStrategy : IGenericMixStrategy
    {
        public ReadOnlyCollection<TEntity> Mix<TEntity>(List<TEntity> entitiesToMix)
        {
            var random = new Random();
            var localCount = Enumerable.Range(0, entitiesToMix.Count).ToList();
            var tmpList = new List<TEntity>();
            while (localCount.Count != 0)
            {
                var randomIndex = random.Next(0, localCount.Count);
                tmpList.Add(entitiesToMix[localCount[randomIndex]]);
                localCount.RemoveAt(randomIndex);
            }
            return new ReadOnlyCollection<TEntity>(tmpList);
        }
    }
}