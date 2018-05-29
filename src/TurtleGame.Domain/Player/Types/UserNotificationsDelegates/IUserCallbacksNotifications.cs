using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;

namespace TurtleGame.Domain.Player.Types
{
    public interface IUserCallbacksNotifications
    {
        ChooseSecondBetDelagate ChooseSecondBet { get; set; }
        ChooseSideOfTrackDelagate ChooseSideOfTrack { get; set; }
        SelectRacingCardDelagate SelectRacingCard { get; set; }
    }
}