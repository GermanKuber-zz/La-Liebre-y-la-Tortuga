using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;
using TurtleGame.Domain.Side;
using TurtleGame.Domain.Tracks.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public class RegularPlayer : IPlayer
    {
        private readonly List<IBetCard> _betCards = new List<IBetCard>();
        private readonly UserCallbacksNotifications _userCallbacksNotifications;
        private readonly IRacingCardManager _racingCardManager;

        public int BetCardsQuantity => _betCards.Count;

        public IReadOnlyCollection<IRacingCard> RacingCards => new ReadOnlyCollection<IRacingCard>(_racingCards);

        private readonly List<IRacingCard> _racingCards = new List<IRacingCard>();

        public RegularPlayer(UserCallbacksNotifications userCallbacksNotifications,
            IRacingCardManager racingCardManager)
        {
            if (userCallbacksNotifications == null)
                throw new ArgumentException(nameof(userCallbacksNotifications));

            _userCallbacksNotifications = userCallbacksNotifications;
            _racingCardManager = racingCardManager;

        }
        public void GiveCard(IBetCard betCard)
        {
            if (_betCards.Count >= 2)
                throw new ArgumentException(nameof(betCard));
            _betCards.Add(betCard);
        }

        public void TakeRacingCard() => _racingCards.Add(_racingCardManager.TakeCard());

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => _userCallbacksNotifications.ChooseSideOfTrack.Invoke(track);
        public bool CardsTurn(Func<IReadOnlyCollection<IRacingCard>, bool> selectedCardsConfirmation)
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
            _betCards.Add(new SecondBetCard(choosedSecondBetCard));
        }
    }
}