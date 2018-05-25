using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Tracks.Interfaces
{
    public interface ITrackContainerToPlay
    {
        SideBoderSelected SideBoder { get; }
        ITrackContainerToPlay Next { get; }
        void SetNext(SideBoderSelected sideBoderSelect);
    }
}