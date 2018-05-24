using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

    public interface IPlaceTrackStrategy
    {
        ReadOnlyCollection<ITrack> PlaceTrack(List<ITrack> tracksToPlace);
    }

    public class PlaceTrackRandomStrategy : IPlaceTrackStrategy
    {
        public ReadOnlyCollection<ITrack> PlaceTrack(List<ITrack> tracksToPlace)
        {
            var random = new Random();
            var localCount = Enumerable.Range(0, tracksToPlace.Count).ToList();
            var tmpList = new List<ITrack>();
            while (localCount.Count() != 0)
            {
                var randomIndex = random.Next(0, localCount.Count());
                tmpList.Add(tracksToPlace[localCount[randomIndex]]);
                localCount.RemoveAt(randomIndex);
            }
            return new ReadOnlyCollection<ITrack>(tmpList);
        }
    }

    public interface ITrack
    {
    }

    public class CommonTrack : ITrack
    {
    }

    public class TrackWithStream : ITrack
    {
    }
}