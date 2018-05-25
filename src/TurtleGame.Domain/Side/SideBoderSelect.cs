using TurtleGame.Domain.Side.Interfaces;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Side
{
    public class SideBoderSelected : ISideBoderSelected
    {
        public ITrack Track { get; }
        public ISideOfTrack SideOfTrack { get; }
        public IBorderOfTrack BorderOfTrack { get; }
        public SideBoderSelected(ITrack track,
            ISideOfTrack sideOfTrack,
            IBorderOfTrack borderOfTrack)
        {
            Track = track;
            SideOfTrack = sideOfTrack;
            BorderOfTrack = borderOfTrack;
        }
        protected SideBoderSelected()
        {

        }
    }
}