using System.Collections.Generic;

namespace TurtleGame.Domain
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