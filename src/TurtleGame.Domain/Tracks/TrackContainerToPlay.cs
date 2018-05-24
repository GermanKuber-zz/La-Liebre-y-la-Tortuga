using System;

namespace TurtleGame.Domain
{
    public class TrackContainerToPlay : ITrackContainerToPlay
    {
        public SideOfTrack SideToPlay { get; private set; }
        public  ITrack CurrentTrack { get; private set; }
        public SideOfTrackEnum Side { get; }
        public ITrackContainerToPlay Next { get; private set; }

        public TrackContainerToPlay(ITrack track, SideOfTrackEnum side)
        {
            if (track == null)
                throw new ArgumentException(nameof(track));
            if (side == null)
                throw new ArgumentException(nameof(side));

            if (side == SideOfTrackEnum.UpSide)
                SideToPlay = track.UpSide;
            if (side == SideOfTrackEnum.DownSide)
                SideToPlay = track.DownSide;
            CurrentTrack = track;
            Side = side;
        }

        public void SetNext(ITrack track, SideOfTrackEnum side)
        {
            if (track == null)
                throw new ArgumentException(nameof(track));
            if (side == null)
                throw new ArgumentException(nameof(side));

            Next = new TrackContainerToPlay(track, side);
        }
    }
}