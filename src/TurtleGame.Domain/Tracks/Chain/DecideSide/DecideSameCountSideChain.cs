using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Side.Enum;
using TurtleGame.Domain.Side.Interfaces;

namespace TurtleGame.Domain.Tracks.Chain.DecideSide
{
    public class DecideSameCountSideChain : DecideSideChain
    {
        public override ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList)
        {
            if (decisionList.Count(x => x == SideOfTrackEnum.DownSide)
                == decisionList.Count(x => x == SideOfTrackEnum.UpSide))
                return new SideOfTrackUp();
            else
                return successor.Decide(decisionList);
        }
    }
}