using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Side.Interfaces;

namespace TurtleGame.Domain.Side
{
    public class SideOfTrackDown : ISideOfTrack
    {
        public SideOfTrackEnum SideType => SideOfTrackEnum.DownSide;

    }
}