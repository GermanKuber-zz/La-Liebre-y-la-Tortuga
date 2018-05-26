using System.Collections.Generic;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IMixTrackStrategy
    {
        IReadOnlyCollection<ITrack> MixTracks(List<ITrack> tracksToMix);
    }
}