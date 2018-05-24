using System;
using System.Collections.Generic;
using static TurtleGame.Domain.TrackBase;

namespace TurtleGame.Domain
{
    public class Player : IPlayer
    {
        private readonly List<IBetCard> _betCards = new List<IBetCard>();
        private readonly Func<ITrack, ISideBoderSelected> _choseSideOfTrack;

        public Player(Func<ITrack, ISideBoderSelected> choseSideOfTrack)
        {
            if (choseSideOfTrack == null)
                throw new ArgumentException(nameof(choseSideOfTrack));
            this._choseSideOfTrack = choseSideOfTrack;
        }
        public void GiveCard(IBetCard betCard) => _betCards.Add(betCard);

        public ISideBoderSelected ChooseSideOfTrack(ITrack track) => _choseSideOfTrack.Invoke(track);
    }
}