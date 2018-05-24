using System.Collections.Generic;

namespace TurtleGame.Domain
{
    public class TrackManager
    {
        public IReadOnlyCollection<ITrack> Track { get; set; }
        private readonly List<ITrack> _allTracks;

        public TrackManager(ITracksFactory tracksFactory)
        {
            _allTracks = tracksFactory.GetTracks();
        }

        public void PlaceTrack(IPlaceTrackStrategy placeTrackStrategy)
        {
            Track = placeTrackStrategy.PlaceTrack(_allTracks);
        }

    }
}