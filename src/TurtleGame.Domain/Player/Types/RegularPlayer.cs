using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types.BetCards;
using TurtleGame.Domain.Player.Types.UserNotificationsDelegates;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public class RegularPlayer : IPlayer
    {
        private readonly IUserCallbacksNotifications _userCallbacksNotifications;
        private readonly IBetCardsPlayerManager _betCardsPlayerManager;
        private readonly IRacingCardManager _racingCardManager;
        private readonly IPreConditionRaicingCards _preConditionRaicingCards;

        public int BetCardsQuantity => _betCardsPlayerManager.BetCardsQuantity;


        public IRacingCards MyRacingCards { get; } = RacingCards.RacingCards.Create(new List<IRacingCard>());

        public RegularPlayer(IUserCallbacksNotifications userCallbacksNotifications,
            IBetCardsPlayerManager betCardsPlayerManager,
            IRacingCardManager racingCardManager,
            IPreConditionRaicingCards preConditionRaicingCards)
        {
            if (userCallbacksNotifications == null)
                throw new ArgumentException(nameof(userCallbacksNotifications));

            _userCallbacksNotifications = userCallbacksNotifications;
            _betCardsPlayerManager = betCardsPlayerManager;
            _racingCardManager = racingCardManager;
            _preConditionRaicingCards = preConditionRaicingCards;
        }

        public void GiveCard(IBetCard betCard) => _betCardsPlayerManager.GiveCard(betCard);

        public void TakeRacingCard() => MyRacingCards.Add(_racingCardManager.TakeCard());

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => _userCallbacksNotifications.ChooseSideOfTrack.Invoke(track);
        public void CardsTurn(SelectedCardsConfirmationDelegate selectedCardsConfirmation)
        {
            var valid = false;

            var selectedCards = _userCallbacksNotifications.SelectRacingCard(MyRacingCards);
            valid = selectedCardsConfirmation(selectedCards) && _preConditionRaicingCards.Validate(selectedCards);
            while (!valid)
            {
                selectedCards = _userCallbacksNotifications.SelectRacingCard(MyRacingCards);
                valid = selectedCardsConfirmation(selectedCards) && _preConditionRaicingCards.Validate(selectedCards);
            }

            selectedCards.ToList().ForEach(x => MyRacingCards.Remove(x));

            Enumerable.Range(0, selectedCards.Count())
                      .ToList()
                      .ForEach(x => MyRacingCards.Add(_racingCardManager.TakeCard()));

        }

        public void ChooseSecondBet()
        {
            var choosedSecondBetCard = _userCallbacksNotifications.ChooseSecondBet.Invoke(MyRacingCards);
            MyRacingCards.Remove(choosedSecondBetCard);
            _betCardsPlayerManager.GiveCard(new SecondBetCard(choosedSecondBetCard));
        }

    }
}