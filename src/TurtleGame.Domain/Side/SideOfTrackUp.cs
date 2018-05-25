using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Side.Interfaces;

namespace TurtleGame.Domain.Side
{
    public class SideOfTrackUp : ISideOfTrack
    {
        public SideOfTrackEnum SideType => SideOfTrackEnum.UpSide;
    }
}