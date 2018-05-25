using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public class TwoPlayers : PlayersBase
    {
        public override void GiveCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            var list = beatsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerOne.GiveCard(list[2]);
            PlayerTwo.GiveCard(list[3]);
        }

        public override int NumberOfPlayers => 2;
        public sealed override IPlayer PlayerOne { get; }
        public sealed override IPlayer PlayerTwo { get; }

        public TwoPlayers(IPlayer playerOne, IPlayer playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }
    }
}