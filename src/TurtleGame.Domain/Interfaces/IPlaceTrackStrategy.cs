using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IMixTrackStrategy
    {
        ReadOnlyCollection<ITrack> MixTracks(List<ITrack> tracksToMix);
    }
}