using System;

namespace TurtleGame.Domain
{
    public class TrackContainerToPlay : ITrackContainerToPlay
    {
        public SideBoderSelected SideBoder { get; private set; }
        public ITrackContainerToPlay Next { get; private set; }

        public TrackContainerToPlay(SideBoderSelected sideBoderSelect)
        {
            if (sideBoderSelect == null)
                throw new ArgumentException(nameof(sideBoderSelect));

            this.SideBoder = sideBoderSelect;
        }

        public void SetNext(SideBoderSelected sideBoderSelect)
        {
            if (sideBoderSelect == null)
                throw new ArgumentException(nameof(sideBoderSelect));

            Next = new TrackContainerToPlay(sideBoderSelect);
        }
    }
}