namespace TurtleGame.Domain
{
    public interface IPlayer
    {
        void GiveCard(IBetCard betCard);
        ISideBoderSelected ChooseSideOfTrack(ITrack track);
    }
}