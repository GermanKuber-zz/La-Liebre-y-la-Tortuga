namespace TurtleGame.Domain
{
    public class StartingLineTrack : TrackBase
    {
        public StartingLineTrack() : base(new SideOfTrackSelector(false, false, true, false),
            new SideOfTrackSelector(false, false, true, false))
        {
        }
    }
}