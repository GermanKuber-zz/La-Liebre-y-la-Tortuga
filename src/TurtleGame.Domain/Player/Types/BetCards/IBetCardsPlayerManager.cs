using TurtleGame.Domain.BetCards;

namespace TurtleGame.Domain.Player.Types.BetCards
{
    public interface IBetCardsPlayerManager
    {
        int BetCardsQuantity { get; }

        void GiveCard(IBetCard betCard);
    }
}