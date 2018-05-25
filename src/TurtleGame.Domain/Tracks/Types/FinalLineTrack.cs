using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Tracks.Types
{
    public class FinalLineTrack : TrackBase
    {
        public FinalLineTrack() : base(new SideOfTrackSelector(true, false, false ,false),
            new SideOfTrackSelector(true, false, false, false))
        {
        }
    }
}