using System.Collections.Generic;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Tracks
{
    public interface ITrackManager
    {
        IReadOnlyCollection<ITrackContainerToPlay> Track { get; set; }

        void PlaceTracks(IEnumerable<IPlayer> players, IMixTrackStrategy placeTrackStrategy);

    }
}