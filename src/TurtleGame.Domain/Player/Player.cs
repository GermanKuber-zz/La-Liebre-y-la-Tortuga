using System;
using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Side;

namespace TurtleGame.Domain.Player
{
    public class Player : IPlayer
    {
        private readonly List<IBetCard> _betCards = new List<IBetCard>();
        private readonly Func<ITrack, ISideBoderSelected> _choseSideOfTrack;

        public int BetCardsQuantity => _betCards.Count;

        public Player(Func<ITrack, ISideBoderSelected> choseSideOfTrack)
        {
            if (choseSideOfTrack == null)
                throw new ArgumentException(nameof(choseSideOfTrack));
            this._choseSideOfTrack = choseSideOfTrack;
        }
        public void GiveCard(IBetCard betCard)
        {
            if (_betCards.Count >= 2)
                throw new ArgumentException(nameof(betCard));
            _betCards.Add(betCard);
        }

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => _choseSideOfTrack.Invoke(track);
    }
}