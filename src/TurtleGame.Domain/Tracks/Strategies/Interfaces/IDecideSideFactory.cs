using TurtleGame.Domain.Tracks.Chain.DecideSide;

namespace TurtleGame.Domain.Tracks.Strategies.Interfaces
{
    public interface IDecideSideFactory
    {
        DecideSideChain Create();
    }
}