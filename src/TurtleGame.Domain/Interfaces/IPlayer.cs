namespace TurtleGame.Domain
{
    public interface IPlayer
    {
        void GiveCard(IBetCard betCard);
        SideOfTrackEnum ChooseSideOfTrack(ITrack track);
    }
}