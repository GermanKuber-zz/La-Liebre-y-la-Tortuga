using System;
using TurtleGame.Domain.Common;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Tracks.Types
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