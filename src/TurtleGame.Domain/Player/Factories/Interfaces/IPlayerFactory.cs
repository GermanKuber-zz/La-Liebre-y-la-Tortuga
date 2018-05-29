using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;

namespace TurtleGame.Domain.Player.Factories.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer Create(ChooseSideOfTrackDelagate chooseSideOfTrack,
            ChooseSecondBetDelagate chooseSecondBet,
            SelectRacingCardDelagate selectRacingCard);
    }
}