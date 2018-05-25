using TurtleGame.Domain.Tracks.Chain.DecideSide;
using TurtleGame.Domain.Tracks.Strategies.Interfaces;

namespace TurtleGame.Domain.Tracks.Strategies
{
    public class DecideSideFactory : IDecideSideFactory
    {
        public DecideSideChain Create()
        {
            var decideMaxCountUpSideChain = new DecideMaxCountUpSideChain();
            var decideMaxCountDownSideChain = new DecideMaxCountDownSideChain();
            var decideSameCountSideChain = new DecideSameCountSideChain();
            decideMaxCountUpSideChain.SetSuccessor(decideMaxCountDownSideChain);
            decideMaxCountDownSideChain.SetSuccessor(decideSameCountSideChain);
            return decideMaxCountUpSideChain;
        }
    }
}