namespace TurtleGame.Domain
{
    public interface ITrackContainerToPlay
    {
        ITrackContainerToPlay Next { get; }
        SideOfTrack SideToPlay { get; }
        SideOfTrackEnum Side { get; }
        ITrack CurrentTrack { get; }
        void SetNext(ITrack track, SideOfTrackEnum side);
    }
}