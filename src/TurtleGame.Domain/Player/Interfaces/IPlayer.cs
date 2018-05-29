using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Interfaces
{
    public delegate bool SelectedCardsConfirmationDelegate(IRacingCards racingCards);

    public interface IPlayer
    {
        int BetCardsQuantity { get; }
        void GiveCard(IBetCard betCard);
        void ChooseSecondBet();
        IRacingCards RacingCards { get; }
        void TakeRacingCard();
        ISideBoderSelected ChooseSideOfTrack(ITrack track);
        bool CardsTurn(SelectedCardsConfirmationDelegate selectedCardsConfirmation);
    }
}