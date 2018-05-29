using System;
using System.Collections.Generic;
using TurtleGame.Domain.BetCards;

namespace TurtleGame.Domain.Player.Types.BetCards
{
    public class BetCardsPlayerManager : IBetCardsPlayerManager
    {
        public static IBetCardsPlayerManager Create() =>
                    new BetCardsPlayerManager();

        private readonly List<IBetCard> _betCards = new List<IBetCard>();
        public int BetCardsQuantity => _betCards.Count;
        public void GiveCard(IBetCard betCard)
        {
            if (_betCards.Count >= 4)
                throw new ArgumentException(nameof(betCard));
            _betCards.Add(betCard);
        }

        protected BetCardsPlayerManager()
        {
            
        }
    }
}