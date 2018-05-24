using System;

namespace TurtleGame.Domain
{
    public interface ITrack
    {
        Guid Id { get; }
        SideOfTrackSelector DownSide { get; }
        SideOfTrackSelector UpSide { get; }
    }
}