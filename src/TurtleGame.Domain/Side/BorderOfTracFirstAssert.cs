using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Side.Interfaces;

namespace TurtleGame.Domain.Side
{
    public class RoundBorderTrack : IBorderOfTrack
    {
        public BorderOfTrackEnum Border => BorderOfTrackEnum.Down;
    }

    public class LineBorderTrack : IBorderOfTrack
    {
        public BorderOfTrackEnum Border => BorderOfTrackEnum.Up;
    }
 

}