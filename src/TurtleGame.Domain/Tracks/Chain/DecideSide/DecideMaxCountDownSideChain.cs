using System.Collections.Generic;
using System.Linq;

namespace TurtleGame.Domain
{
    public class DecideMaxCountDownSideChain : DecideSideChain
    {
        public override ISideOfTrack Decide(IReadOnlyCollection<SideOfTrackEnum> decisionList)
        {
            if (decisionList.Where(x => x == SideOfTrackEnum.DownSide).Count()
                > decisionList.Where(x => x == SideOfTrackEnum.UpSide).Count())
                return new SideOfTrackDown();
            else
                return successor.Decide(decisionList);
        }
    }
}