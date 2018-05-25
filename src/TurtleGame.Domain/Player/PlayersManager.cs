using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.Player.Types.Interfaces;
using TurtleGame.SharedKernel.Strategies;

namespace TurtleGame.Domain.Player
{
    public class PlayersManager : IPlayersManager
    {
        public IPlayers Players { get; }

        public PlayersManager(IPlayers players)
        {
            Players = players;
        }

        public void GiveCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            if (beatsCards == null || beatsCards.Count != 5)
                throw new ArgumentException(nameof(beatsCards));

            var beatsCardsLocal = beatsCards.ToList();
            var randomMix = new RandomMixStrategy();

            Players.GiveCards(randomMix.Mix(beatsCardsLocal).ToList());

           
        }
    }
}