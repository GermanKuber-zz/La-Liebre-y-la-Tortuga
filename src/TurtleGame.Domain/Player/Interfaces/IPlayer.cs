using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Interfaces
{
    public interface IPlayer
    {
        void GiveCard(IBetCard betCard);
        ISideBoderSelected ChooseSideOfTrack(ITrack track);
    }
}