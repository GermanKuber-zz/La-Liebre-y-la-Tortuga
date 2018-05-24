namespace TurtleGame.Domain
{
    public interface ITrackContainerToPlay
    {
        SideBoderSelect SideBoder { get; }
        ITrackContainerToPlay Next { get; }
        void SetNext(SideBoderSelect sideBoderSelect);
    }
}