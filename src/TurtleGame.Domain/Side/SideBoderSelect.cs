namespace TurtleGame.Domain
{
    public class SideBoderSelect
    {
        public ITrack Track { get; }
        public ISideOfTrack SideOfTrack { get; }
        public IBorderOfTrack BorderOfTrack { get; }
        public SideBoderSelect(ITrack track,
            ISideOfTrack sideOfTrack,
            IBorderOfTrack borderOfTrack)
        {
            Track = track;
            SideOfTrack = sideOfTrack;
            BorderOfTrack = borderOfTrack;
        }

    }
}