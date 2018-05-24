using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TurtleGame.Domain
{
    public interface IPlaceTrackStrategy
    {
        ReadOnlyCollection<ITrack> PlaceTracks(List<ITrack> tracksToPlace);
    }

}