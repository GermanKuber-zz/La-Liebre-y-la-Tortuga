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
            tmpList.Add(new StartingLineTrack());
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
        Guid Id { get; }
    }

    public abstract class Entity
    {
        public Guid Id { get; protected set; }

    }

    public abstract class TrackBase : Entity, ITrack
    {
        private readonly SideOfTrack _downSide;
        private readonly SideOfTrack _upSide;

        public TrackBase(SideOfTrack downSide, SideOfTrack upSide)
        {
            _downSide = downSide;
            _upSide = upSide;
            Id = Guid.NewGuid();
        }
    }

    public class CommonTrack : TrackBase
    {
        public CommonTrack(SideOfTrack upSide, SideOfTrack downSide) : base(upSide, downSide)
        {
        }
    }
    public class StartingLineTrack : TrackBase
    {
        public StartingLineTrack() : base(new SideOfTrack(false, false, true, false),
                                          new SideOfTrack(false, false, true, false))
        {
        }
    }
    public class TrackWithStream : TrackBase
    {
        public TrackWithStream(SideOfTrack upSide, SideOfTrack downSide) : base(upSide, downSide)
        {
        }
    }



    public class SideOfTrack
    {
        public bool VerticalDownEnable { get; }
        public bool VerticalUpEnable { get; }
        public bool VerticalLeftEnable { get; }
        public bool VerticalRigthEnable { get; }

        public SideOfTrack(bool verticalDownEnable,
            bool verticalUpEnable,
            bool verticalLeftEnable,
            bool verticalRigthEnable)
        {
            VerticalDownEnable = verticalDownEnable;
            VerticalUpEnable = verticalUpEnable;
            VerticalLeftEnable = verticalLeftEnable;
            VerticalRigthEnable = verticalRigthEnable;
        }
    }
}