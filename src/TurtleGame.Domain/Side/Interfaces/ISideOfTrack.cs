using TurtleGame.Domain.Side.Enum;

namespace TurtleGame.Domain.Side.Interfaces
{
    public interface ISideOfTrack
    {
        SideOfTrackEnum SideType { get; }
    }
}