using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Animals;
using TurtleGame.Domain.Common;
using TurtleGame.Domain.Player;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Tracks
{
    public interface ITrackContainerToPlays : ICollectionsBase<ITrackContainerToPlay>
    {
    }
    public class TrackContainerToPlays : EntitiesCollectionsBase<ITrackContainerToPlay>, ITrackContainerToPlays
    {
        public TrackContainerToPlays(IEnumerable<ITrackContainerToPlay> trackContainerToPlayS) : base(trackContainerToPlayS.ToList())
        {

        }
    }
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