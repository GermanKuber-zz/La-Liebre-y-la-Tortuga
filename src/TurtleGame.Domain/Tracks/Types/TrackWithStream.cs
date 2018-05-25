using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Tracks.Types
{
    public class TrackWithStream : TrackBase
    {
        public TrackWithStream(SideOfTrackSelector upSide, SideOfTrackSelector downSide) : base(upSide, downSide)
        {
        }
    }
}