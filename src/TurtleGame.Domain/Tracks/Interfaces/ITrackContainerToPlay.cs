namespace TurtleGame.Domain
{
    public interface ITrackContainerToPlay
    {
        SideBoderSelected SideBoder { get; }
        ITrackContainerToPlay Next { get; }
        void SetNext(SideBoderSelected sideBoderSelect);
    }
}