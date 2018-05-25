using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;

namespace TurtleGame.Domain.Player.Types
{
    public class FourPlayers : ThreePlayers
    {
        public override int NumberOfPlayers => 4;

        public sealed override IPlayer PlayerFour { get; }

        public FourPlayers(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            : base(playerOne, playerTwo, playerThree)
        {
            PlayerFour = playerFour;
        }
        public override void GiveCards(IReadOnlyCollection<IBetCard> beatsCards)
        {
            var list = beatsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerThree.GiveCard(list[2]);
            PlayerFour.GiveCard(list[3]);
        }
    }
}