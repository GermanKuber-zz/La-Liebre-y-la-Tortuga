using System.Collections.Generic;

namespace TurtleGame.SharedKernel.Strategies.Interfaces
{
    public interface IGenericMixStrategy
    {
        IReadOnlyCollection<TEntity> Mix<TEntity>(List<TEntity> entitiesToMix);
    }
}