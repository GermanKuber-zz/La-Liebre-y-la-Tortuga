using System;
using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Tracks.Interfaces
{
    public interface ITrack
    {
        Guid Id { get; }
        SideOfTrackSelector DownSide { get; }
        SideOfTrackSelector UpSide { get; }
    }
}