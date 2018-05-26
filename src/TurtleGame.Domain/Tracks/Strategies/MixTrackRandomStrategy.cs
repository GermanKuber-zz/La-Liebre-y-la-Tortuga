using System.Collections.Generic;
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
        public IReadOnlyCollection<ITrack> MixTracks(List<ITrack> tracksToMix) => _genericMixStrategy.Mix(tracksToMix);

      
    }
}