namespace TurtleGame.Domain
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