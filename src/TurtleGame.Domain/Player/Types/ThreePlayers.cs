using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public class ThreePlayers : TwoPlayers
    {
        public override int NumberOfPlayers => 3;

        public sealed override IPlayer PlayerThree { get; }

        public ThreePlayers(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree)
            : base(playerOne, playerTwo)
        {
            PlayerThree = playerThree;
        }
        public override void GiveCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            var list = beatsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerThree.GiveCard(list[2]);
        }
    }
}