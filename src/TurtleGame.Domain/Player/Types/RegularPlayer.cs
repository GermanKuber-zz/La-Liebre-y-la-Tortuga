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
        private readonly Func<ITrack, ISideBoderSelected> _chooseSideOfTrack;
        private readonly IRacingCardManager _racingCardManager;

        public int BetCardsQuantity => _betCards.Count;

        public IReadOnlyCollection<IRacingCard> RacingCards => new ReadOnlyCollection<IRacingCard>(_racingCards);

        private readonly List<IRacingCard> _racingCards = new List<IRacingCard>();
        private readonly Func<IReadOnlyCollection<IRacingCard>, IRacingCard> _chooseSecondBet;

        public RegularPlayer(Func<ITrack, ISideBoderSelected> chooseSideOfTrack,
            Func<IReadOnlyCollection<IRacingCard>, IRacingCard> chooseSecondBet,
            IRacingCardManager racingCardManager)
        {
            if (chooseSideOfTrack == null)
                throw new ArgumentException(nameof(chooseSideOfTrack));
            if (chooseSecondBet == null)
                throw new ArgumentException(nameof(chooseSecondBet));

            _chooseSideOfTrack = chooseSideOfTrack;
            _racingCardManager = racingCardManager;
            _chooseSecondBet = chooseSecondBet;
        }
        public void GiveCard(IBetCard betCard)
        {
            if (_betCards.Count >= 2)
                throw new ArgumentException(nameof(betCard));
            _betCards.Add(betCard);
        }

        public void TakeRacingCard() => _racingCards.Add(_racingCardManager.TakeCard());

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => _chooseSideOfTrack.Invoke(track);
        public void ChooseSecondBet()
        {
            var choosedSecondBetCard = _chooseSecondBet.Invoke(_racingCards);
            _racingCards.Remove(choosedSecondBetCard);
            _betCards.Add(new SecondBetCard(choosedSecondBetCard));
        }
    }
}