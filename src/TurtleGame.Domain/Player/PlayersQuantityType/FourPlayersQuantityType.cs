using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public class FourPlayersQuantityType : ThreePlayersQuantityType
    {
        public override int NumberOfPlayers => 4;

        public sealed override IPlayer PlayerFour { get; }

        public FourPlayersQuantityType(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IPlayer playerFour)
            : base(playerOne, playerTwo, playerThree)
        {
            PlayerFour = playerFour;
        }
        public override void GiveCards(IReadOnlyCollection<IBetCard> betsCards)
        {
            var list = betsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerThree.GiveCard(list[2]);
            PlayerFour.GiveCard(list[3]);
        }
        public override void TakeCard()
        {
            base.TakeCard();
            PlayerFour.TakeRacingCard();
        }
    }
}