using TurtleGame.Domain.Condition.Factories;
using TurtleGame.Domain.Player.Factories.Interfaces;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Managers;

namespace TurtleGame.Domain.Player.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IRacingCardManager _racingCardManager;
        private readonly IPreConditionRaicingCardsFactory _preConditionRaicingCardsFactory;

        public PlayerFactory(IRacingCardManager racingCardManager,
            IPreConditionRaicingCardsFactory preConditionRaicingCardsFactory)
        {
            _racingCardManager = racingCardManager;
            _preConditionRaicingCardsFactory = preConditionRaicingCardsFactory;
        }
        public IPlayer Create(ChooseSideOfTrackDelagate chooseSideOfTrack,
            ChooseSecondBetDelagate chooseSecondBet,
            SelectRacingCardDelagate selectRacingCard) =>
            new RegularPlayer(UserCallbacksNotifications.Create(chooseSideOfTrack,
                                                    chooseSecondBet,
                                                    selectRacingCard),
                                                    BetCardsPlayerManager.Create(),
                                                    _racingCardManager,
                                                    _preConditionRaicingCardsFactory.Create());

    }
}
