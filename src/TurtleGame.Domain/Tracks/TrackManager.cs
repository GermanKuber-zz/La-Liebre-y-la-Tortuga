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
        private readonly IDecideSideFactory _decideSideFactory;

        public TrackManager(ITracksFactory tracksFactory,
            IDecideSideFactory decideSideFactory)
        {
            _allTracks = tracksFactory.GetTracks();
            this._decideSideFactory = decideSideFactory;
        }

        public void PlaceTracks(IEnumerable<IPlayer> players, IPlaceTrackStrategy placeTrackStrategy)
        {
            var tracks = placeTrackStrategy.PlaceTracks(_allTracks);
            var listTmp = new List<ITrackContainerToPlay>();

            listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(new StartingLineTrack(), new SideOfTrackDown(), new RoundBorderTrack())));

            foreach (var track in tracks)
            {
                var listOfDesicions = new List<SideOfTrackEnum>();
                foreach (var player in players)
                    listOfDesicions.Add(player.ChooseSideOfTrack(track).SideOfTrack.SideType);


                var sideOfTrack = _decideSideFactory.Create()
                                                    .Decide(new ReadOnlyCollection<SideOfTrackEnum>(listOfDesicions));

                listTmp.Add(new TrackContainerToPlay(new SideBoderSelected(track, sideOfTrack, new RoundBorderTrack())));

            }

            Track = new ReadOnlyCollection<ITrackContainerToPlay>(listTmp);
        }
    }
    public abstract class DecideSideChain
    {
        protected DecideSideChain successor;

        public void SetSuccessor(DecideSideChain successor)
        {
            this.successor = successor;
        }

        public abstract ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList);
    }
    public class DecideMaxCountUpSideChain : DecideSideChain
    {
        public override ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList)
        {
            if (decisionList.Where(x => x == SideOfTrackEnum.DownSide).Count()
                < decisionList.Where(x => x == SideOfTrackEnum.UpSide).Count())
                return new SideOfTrackUp();
            else
                return successor.Decide(decisionList);
        }
    }
    public class DecideMaxCountDownSideChain : DecideSideChain
    {
        public override ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList)
        {
            if (decisionList.Where(x => x == SideOfTrackEnum.DownSide).Count()
                > decisionList.Where(x => x == SideOfTrackEnum.UpSide).Count())
                return new SideOfTrackDown();
            else
                return successor.Decide(decisionList);
        }
    }
    public class DecideSameCountSideChain : DecideSideChain
    {
        public override ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList)
        {
            if (decisionList.Where(x => x == SideOfTrackEnum.DownSide).Count()
                == decisionList.Where(x => x == SideOfTrackEnum.UpSide).Count())
                return new SideOfTrackUp();
            else
                return successor.Decide(decisionList);
        }
    }
}