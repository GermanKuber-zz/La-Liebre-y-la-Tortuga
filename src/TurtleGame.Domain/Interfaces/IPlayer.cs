using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayer
    {
        void GiveCard(IBetCard betCard);
        ISideBoderSelected ChooseSideOfTrack(ITrack track);
    }
}