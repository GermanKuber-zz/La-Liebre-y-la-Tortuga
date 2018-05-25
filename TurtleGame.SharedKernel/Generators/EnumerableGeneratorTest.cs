using System;
using System.Collections.Generic;
using System.Linq;

namespace TurtleGame.SharedKernel.Generators
{
    public static class EnumerableGenerator
    {
        public static List<TEntity> Generate<TEntity>(int count, Func<int, TEntity> createEntity) => Enumerable.Range(1, count)
            .Select(createEntity).ToList();
    }
}