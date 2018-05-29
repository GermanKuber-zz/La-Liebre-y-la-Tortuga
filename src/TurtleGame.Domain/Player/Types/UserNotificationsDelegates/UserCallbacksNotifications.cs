using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;

namespace TurtleGame.Domain.Player.Types
{
    public class UserCallbacksNotifications : IUserCallbacksNotifications
    {


        public ChooseSideOfTrackDelagate ChooseSideOfTrack { get; set; }
        public ChooseSecondBetDelagate ChooseSecondBet { get; set; }
        public SelectRacingCardDelagate SelectRacingCard { get; set; }

        private UserCallbacksNotifications(ChooseSideOfTrackDelagate chooseSideOfTrack,
            ChooseSecondBetDelagate chooseSecondBet,
            SelectRacingCardDelagate selectRacingCard)
        {
            ChooseSideOfTrack = chooseSideOfTrack;
            ChooseSecondBet = chooseSecondBet;
            SelectRacingCard = selectRacingCard;
        }

        public static IUserCallbacksNotifications Create(ChooseSideOfTrackDelagate chooseSideOfTrack,
            ChooseSecondBetDelagate chooseSecondBet,
            SelectRacingCardDelagate selectRacingCard) =>
            new UserCallbacksNotifications(chooseSideOfTrack, chooseSecondBet, selectRacingCard);
    }
}