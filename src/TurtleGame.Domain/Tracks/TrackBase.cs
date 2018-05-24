using System;

namespace TurtleGame.Domain
{
    public abstract class TrackBase : Entity, ITrack
    {
        public enum SideOfTrackEnum
        {
            UpSide,
            DownSide
        }

        public ITrack Next { get; private set; }

        private readonly SideOfTrack _downSide;
        private readonly SideOfTrack _upSide;
        public SideOfTrack Current { get; private set; }

        public TrackBase(SideOfTrack upSide, SideOfTrack downSide)
        {
            _downSide = downSide;
            _upSide = upSide;
            Id = Guid.NewGuid();
        }


        public void SetNextUpSide(CommonTrack nextTrack)
        {
            if (nextTrack == null)
                throw new ArgumentException(nameof(nextTrack));

            Next = nextTrack;
        }
        public void SetNextUpSide(CommonTrack nextTrack, SideOfTrackEnum sideOfTrackEnum)
        {
            if (nextTrack == null)
                throw new ArgumentException(nameof(nextTrack));
            if (sideOfTrackEnum == null)
                throw new ArgumentException(nameof(sideOfTrackEnum));

            switch (sideOfTrackEnum)
            {
                case SideOfTrackEnum.UpSide:
                    Current = _upSide;
                    return;
                case SideOfTrackEnum.DownSide:
                    Current = _downSide;
                    return;
            }

            SetNextUpSide(nextTrack);
        }
        public void SelectUpSide()
        {
            Current = _upSide;
        }

        public void SelectDownSide()
        {
            Current = _downSide;

        }
    }
}