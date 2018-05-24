using System;

namespace TurtleGame.Domain
{
    public interface ITrack
    {
        Guid Id { get; }
        SideOfTrack DownSide { get; }
        SideOfTrack UpSide { get; }
    }
}