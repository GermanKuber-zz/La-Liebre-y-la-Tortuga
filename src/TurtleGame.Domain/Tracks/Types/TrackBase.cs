using System;

namespace TurtleGame.Domain
{
    public abstract class TrackBase : Entity, ITrack
    {
        public SideOfTrackSelector DownSide { get; private set; }
        public SideOfTrackSelector UpSide { get; private set; }

        public TrackBase(SideOfTrackSelector upSide, SideOfTrackSelector downSide)
        {
            DownSide = downSide;
            UpSide = upSide;
            Id = Guid.NewGuid();
        }

    }
}