using System.Collections.Generic;

namespace TurtleGame.Domain.Interfaces
{
    public interface ITracksFactory
    {
        List<ITrack> GetTracks();
    }
}