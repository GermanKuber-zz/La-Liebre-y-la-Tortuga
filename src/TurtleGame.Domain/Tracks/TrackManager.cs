using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Tracks.Interfaces;
using TurtleGame.Domain.Tracks.Strategies;
using TurtleGame.Domain.Tracks.Strategies.Interfaces;
using TurtleGame.Domain.Tracks.Types;

namespace TurtleGame.Domain.Tracks
{
    public class TrackManager
    {
        public IReadOnlyCollection<ITrackContainerToPlay> Track { get; set; }
        private readonly List<ITrack> _allTracks;
        private readonly IDecideSideFactory _decideSideFactory;

        public TrackManager(ITracksFactory tracksFactory,
            IDecideSideFactory decideSideFactory)
        {
            _allTracks = tracksFactory.GetTracks();
            this._decideSideFactory = decideSideFactory;
        }

        public void PlaceTracks(IEnumerable<IPlayer> players, IMixTrackStrategy placeTrackStrategy)
        {
            var tracks = placeTrackStrategy.MixTracks(_allTracks);
            var listTmp = new List<ITrackContainerToPlay>();

            InsertStartLine(listTmp);

            foreach (var track in tracks)
            {
                var listOfDesicions = new List<SideOfTrackEnum>();
                foreach (var player in players)
                    listOfDesicions.Add(player.ChooseSideOfTrack(track).SideOfTrack.SideType);


                var sideOfTrack = _decideSideFactory.Create()
                                                    .Decide(new ReadOnlyCollection<SideOfTrackEnum>(listOfDesicions));

                listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(track, sideOfTrack, new RoundBorderTrack())));

            }
            InsertLastLine(listTmp);

            Track = new ReadOnlyCollection<ITrackContainerToPlay>(listTmp);
        }

        private static void InsertStartLine(List<ITrackContainerToPlay> listTmp)
        {
            listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(new StartingLineTrack(), new SideOfTrackDown(), new RoundBorderTrack())));
        }
        private static void InsertLastLine(List<ITrackContainerToPlay> listTmp)
        {
            listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(new FinalLineTrack(), new SideOfTrackDown(), new RoundBorderTrack())));
        }
    }
}