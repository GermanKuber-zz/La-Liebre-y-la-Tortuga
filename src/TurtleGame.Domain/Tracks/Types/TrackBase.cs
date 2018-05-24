using System;

namespace TurtleGame.Domain
{
    public abstract class TrackBase : Entity, ITrack
    {
        public SideOfTrack DownSide { get; private set; }
        public SideOfTrack UpSide { get; private set; }

        public TrackBase(SideOfTrack upSide, SideOfTrack downSide)
        {
            DownSide = downSide;
            UpSide = upSide;
            Id = Guid.NewGuid();
        }

    }
}