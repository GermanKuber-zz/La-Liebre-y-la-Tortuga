using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TurtleGame.Domain
{
    public interface IPlaceTrackStrategy
    {
        ReadOnlyCollection<ITrack> PlaceTrack(List<ITrack> tracksToPlace);
    }
}