using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TurtleGame.Domain.Tracks.Strategies.Interfaces
{
    public interface IGenericMixStrategy
    {
        ReadOnlyCollection<TEntity> Mix<TEntity>(List<TEntity> entitiesToMix);
    }
}