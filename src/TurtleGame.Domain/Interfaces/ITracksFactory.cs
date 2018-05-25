using System.Collections.Generic;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface ITracksFactory
    {
        List<ITrack> GetTracks();
    }
}