using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TurtleGame.Domain
{
    public class TrackManager
    {
        public IReadOnlyCollection<ITrackContainerToPlay> Track { get; set; }
        private List<ITrack> _allTrackOrder;
        private readonly List<ITrack> _allTracks;

        public TrackManager(ITracksFactory tracksFactory)
        {
            _allTracks = tracksFactory.GetTracks();
        }

        public void PlaceTracks(IEnumerable<IPlayer> players, IPlaceTrackStrategy placeTrackStrategy)
        {
            var tracks = placeTrackStrategy.PlaceTracks(_allTracks);
            var listTmp = new List<ITrackContainerToPlay>();

            foreach (var track in tracks)
            {
                var listOfDesicions = new List<SideOfTrackEnum>();
                foreach (var player in players)
                    listOfDesicions.Add(player.ChooseSideOfTrack(track).SideOfTrack.SideType);

                if (listOfDesicions.Where(x => x == SideOfTrackEnum.DownSide).Count() >
                    listOfDesicions.Where(x => x == SideOfTrackEnum.UpSide).Count())
                    listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(track, new SideOfTrackDown(), new BorderOfTracFirstAssert())));
                if (listOfDesicions.Where(x => x == SideOfTrackEnum.DownSide).Count() <
                   listOfDesicions.Where(x => x == SideOfTrackEnum.UpSide).Count())
                    listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(track, new SideOfTrackUp(), new BorderOfTracFirstAssert())));
                if (listOfDesicions.Where(x => x == SideOfTrackEnum.DownSide).Count() ==
                   listOfDesicions.Where(x => x == SideOfTrackEnum.UpSide).Count())
                    listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(track, new SideOfTrackUp(), new BorderOfTracFirstAssert())));
            }

            Track = new ReadOnlyCollection<ITrackContainerToPlay>(listTmp);
        }

    }
}