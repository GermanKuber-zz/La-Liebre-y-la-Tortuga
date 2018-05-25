using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TurtleGame.SharedKernel.Strategies.Interfaces
{
    public interface IGenericMixStrategy
    {
        ReadOnlyCollection<TEntity> Mix<TEntity>(List<TEntity> entitiesToMix);
    }
}