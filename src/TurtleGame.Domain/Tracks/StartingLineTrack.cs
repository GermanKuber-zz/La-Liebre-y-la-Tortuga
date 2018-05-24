namespace TurtleGame.Domain
{
    public class StartingLineTrack : TrackBase
    {
        public StartingLineTrack() : base(new SideOfTrack(false, false, true, false),
            new SideOfTrack(false, false, true, false))
        {
        }
    }
}