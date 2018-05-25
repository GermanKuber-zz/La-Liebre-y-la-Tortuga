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
            if (decisionList.Where(x => x == SideOfTrackEnum.DownSide).Count()
                == decisionList.Where(x => x == SideOfTrackEnum.UpSide).Count())
                return new SideOfTrackUp();
            else
                return successor.Decide(decisionList);
        }
    }
}