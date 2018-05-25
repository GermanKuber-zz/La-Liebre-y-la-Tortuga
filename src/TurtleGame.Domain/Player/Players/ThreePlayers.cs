using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Player.Players
{
    public class ThreePlayers : TwoPlayers
    {
        public override int NumberOfPlayers => 3;
        public sealed override IPlayer PlayerThree { get; }

        protected List<IRacingCard> RacingCardsPlayerThree = new List<IRacingCard>();
        public ThreePlayers(IPlayer playerOne, IPlayer playerTwo, IPlayer playerThree, IRacingCardManager racingCardManager)
            : base(playerOne, playerTwo,racingCardManager)
        {
            PlayerThree = playerThree;
        }

        public override void GiveCards(IReadOnlyCollection<IBetCard> betsCards)
        {
            var list = betsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerThree.GiveCard(list[2]);
        }
        public override void TakeCard()
        {
            base.TakeCard();
            RacingCardsPlayerThree.Add(RacingCardManager.TakeCard());
        }
    }
}