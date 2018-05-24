using System;
using System.Collections.Generic;

namespace TurtleGame.Domain
{
    public class Player : IPlayer
    {
        private readonly List<IBetCard> _betCards = new List<IBetCard>();
        public void GiveCard(IBetCard betCard) => _betCards.Add(betCard);
    }
}