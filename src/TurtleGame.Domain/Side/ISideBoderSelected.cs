using TurtleGame.Domain.Side.Interfaces;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Side
{
    public interface ISideBoderSelected
    {
        IBorderOfTrack BorderOfTrack { get; }
        ISideOfTrack SideOfTrack { get; }
        ITrack Track { get; }
    }
}