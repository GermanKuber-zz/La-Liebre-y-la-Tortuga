using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side.Interfaces;

namespace TurtleGame.Domain.Side
{
    public interface ISideBoderSelected
    {
        IBorderOfTrack BorderOfTrack { get; }
        ISideOfTrack SideOfTrack { get; }
        ITrack Track { get; }
    }
}