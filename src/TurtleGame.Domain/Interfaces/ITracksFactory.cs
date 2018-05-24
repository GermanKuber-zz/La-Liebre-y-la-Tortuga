using System.Collections.Generic;

namespace TurtleGame.Domain
{
    public interface ITracksFactory
    {
        List<ITrack> GetTracks();
    }
}