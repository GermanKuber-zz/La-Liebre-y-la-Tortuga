using System;
using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Tracks.Interfaces
{
    public interface ITrack
    {
        SideOfTrackSelector DownSide { get; }
        SideOfTrackSelector UpSide { get; }
    }
}