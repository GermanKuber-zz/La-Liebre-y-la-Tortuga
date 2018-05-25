using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Tracks.Interfaces;
using TurtleGame.SharedKernel.Strategies.Interfaces;

namespace TurtleGame.Domain.Tracks.Strategies
{
    public class MixTrackRandomStrategy : IMixTrackStrategy
    {
        private readonly IGenericMixStrategy _genericMixStrategy;

        public MixTrackRandomStrategy(IGenericMixStrategy genericMixStrategy)
        {
            _genericMixStrategy = genericMixStrategy;
        }
        public ReadOnlyCollection<ITrack> MixTracks(List<ITrack> tracksToMix) => _genericMixStrategy.Mix(tracksToMix);

      
    }
}