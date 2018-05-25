using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Tracks.Types
{
    public class CommonTrack : TrackBase
    {
        public CommonTrack(SideOfTrackSelector upSide, SideOfTrackSelector downSide) : base(upSide, downSide)
        {
        }
    }
}