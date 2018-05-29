namespace TurtleGame.Domain.Player.Types.UserNotificationsDelegates
{
    public interface IUserCallbacksNotifications
    {
        ChooseSecondBetDelagate ChooseSecondBet { get; set; }
        ChooseSideOfTrackDelagate ChooseSideOfTrack { get; set; }
        SelectRacingCardDelagate SelectRacingCard { get; set; }
    }
}