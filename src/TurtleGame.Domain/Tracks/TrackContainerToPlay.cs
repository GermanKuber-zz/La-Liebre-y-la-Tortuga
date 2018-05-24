using System;

namespace TurtleGame.Domain
{
    public class TrackContainerToPlay : ITrackContainerToPlay
    {
        public SideBoderSelect SideBoder { get; private set; }
        public ITrackContainerToPlay Next { get; private set; }

        public TrackContainerToPlay(SideBoderSelect sideBoderSelect)
        {
            if (sideBoderSelect == null)
                throw new ArgumentException(nameof(sideBoderSelect));

            this.SideBoder = sideBoderSelect;
        }

        public void SetNext(SideBoderSelect sideBoderSelect)
        {
            if (sideBoderSelect == null)
                throw new ArgumentException(nameof(sideBoderSelect));

            Next = new TrackContainerToPlay(sideBoderSelect);
        }
    }
}