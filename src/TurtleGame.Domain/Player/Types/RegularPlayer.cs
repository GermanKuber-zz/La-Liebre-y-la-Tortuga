using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.Types.BetCards;
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

        public int BetCardsQuantity => _betCardsPlayerManager.BetCardsQuantity;

        public IReadOnlyCollection<IRacingCard> RacingCards => new ReadOnlyCollection<IRacingCard>(_racingCards);

        private readonly List<IRacingCard> _racingCards = new List<IRacingCard>();

        public RegularPlayer(IUserCallbacksNotifications userCallbacksNotifications,
            IBetCardsPlayerManager betCardsPlayerManager,
            IRacingCardManager racingCardManager)
        {
            if (userCallbacksNotifications == null)
                throw new ArgumentException(nameof(userCallbacksNotifications));

            _userCallbacksNotifications = userCallbacksNotifications;
            _betCardsPlayerManager = betCardsPlayerManager;
            _racingCardManager = racingCardManager;

        }

        public void GiveCard(IBetCard betCard) => _betCardsPlayerManager.GiveCard(betCard);

        public void TakeRacingCard() => _racingCards.Add(_racingCardManager.TakeCard());

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => _userCallbacksNotifications.ChooseSideOfTrack.Invoke(track);
        public bool CardsTurn(SelectedCardsConfirmationDelegate selectedCardsConfirmation)
        {
            var selectedCards = _userCallbacksNotifications.SelectRacingCard(RacingCards);
            if (selectedCardsConfirmation(selectedCards))
            {
                //Remove card form the main cards list
            }

            return true;
        }

        public void ChooseSecondBet()
        {
            var choosedSecondBetCard = _userCallbacksNotifications.ChooseSecondBet.Invoke(_racingCards);
            _racingCards.Remove(choosedSecondBetCard);
            _betCardsPlayerManager.GiveCard(new SecondBetCard(choosedSecondBetCard));
        }
    }
}