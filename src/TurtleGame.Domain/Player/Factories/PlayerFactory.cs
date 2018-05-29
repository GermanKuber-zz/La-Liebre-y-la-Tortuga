using TurtleGame.Domain.Player.Factories.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Player.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IRacingCardManager _racingCardManager;

        public PlayerFactory(IRacingCardManager racingCardManager)
        {
            _racingCardManager = racingCardManager;
        }
        public IPlayer Create(ChooseSideOfTrackDelagate chooseSideOfTrack,
            ChooseSecondBetDelagate chooseSecondBet,
            SelectRacingCardDelagate selectRacingCard) =>
            new RegularPlayer(UserCallbacksNotifications.Create(chooseSideOfTrack,
                                                    chooseSecondBet,
                                                    selectRacingCard),
                                                    BetCardsPlayerManager.Create(),
                                                    _racingCardManager);

    }
}
