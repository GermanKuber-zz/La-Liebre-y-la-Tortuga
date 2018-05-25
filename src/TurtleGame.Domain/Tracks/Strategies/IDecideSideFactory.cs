using TurtleGame.Domain.Tracks.Chain.DecideSide;

namespace TurtleGame.Domain.Tracks.Strategies
{
    public interface IDecideSideFactory
    {
        DecideSideChain Create();
    }
}