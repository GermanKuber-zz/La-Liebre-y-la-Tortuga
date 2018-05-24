namespace TurtleGame.Domain
{
    public interface ISideBoderSelected
    {
        IBorderOfTrack BorderOfTrack { get; }
        ISideOfTrack SideOfTrack { get; }
        ITrack Track { get; }
    }
}