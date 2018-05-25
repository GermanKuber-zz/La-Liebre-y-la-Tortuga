using System.Collections.Generic;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Side.Interfaces;

namespace TurtleGame.Domain.Tracks.Chain.DecideSide
{
    public abstract class DecideSideChain
    {
        protected DecideSideChain successor;

        public void SetSuccessor(DecideSideChain successor)
        {
            this.successor = successor;
        }

        public abstract ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList);
    }
}