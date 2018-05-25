using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;

namespace TurtleGame.Domain.Player.Players
{
    public class FivePlayers : FourPlayers
    {
        public override int NumberOfPlayers => 5;

        public sealed override IPlayer PlayerFive { get; }

        public FivePlayers(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour, IPlayer playerFive,
            IRacingCardManager racingCardManager)
            : base(playerOne, playerTwo, playerThree, playerFour, racingCardManager)
        {
            PlayerFive = playerFive;
        }
        public override void GiveCards(IReadOnlyCollection<IBetCard> betsCards)
        {
            var list = betsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerThree.GiveCard(list[2]);
            PlayerFour.GiveCard(list[3]);
            PlayerFive.GiveCard(list[4]);
        }
    }
}