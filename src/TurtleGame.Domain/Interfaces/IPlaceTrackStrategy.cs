using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TurtleGame.Domain.Interfaces
{
    public interface IMixTrackStrategy
    {
        ReadOnlyCollection<ITrack> MixTracks(List<ITrack> tracksToMix);
    }
}