using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Interfaces
{
    public delegate bool SelectedCardsConfirmationDelegate(IRacingCards racingCards);
    public delegate bool DeskIsValidForTheNextPlayerDelegate();

    public interface IPlayer
    {
        int BetCardsQuantity { get; }
        void GiveCard(IBetCard betCard);
        void ChooseSecondBet();
        void TakeRacingCard();
        IRacingCards MyRacingCards { get; }
        ISideBoderSelected ChooseSideOfTrack(ITrack track);
        void CardsTurn(SelectedCardsConfirmationDelegate selectedCardsConfirmation);
    }
}