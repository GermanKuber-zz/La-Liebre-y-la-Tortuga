using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Interfaces;
using TurtleGame.Domain.RacingCards;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Player.Players
{
    public class TwoPlayers : PlayersBase
    {
        public override int NumberOfPlayers => 2;
        public sealed override IPlayer PlayerOne { get; }
        public sealed override IPlayer PlayerTwo { get; }

        protected List<IRacingCard> RacingCardsPlayerOne = new List<IRacingCard>();
        protected List<IRacingCard> RacingCardsPlayerTwo = new List<IRacingCard>();
        public TwoPlayers(IPlayer playerOne, IPlayer playerTwo, IRacingCardManager racingCardManager)
            : base(racingCardManager)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }
        public override void GiveCards(IReadOnlyCollection<IBetCard> betsCards)
        {
            var list = betsCards.ToList();
            PlayerOne.GiveCard(list[0]);
            PlayerTwo.GiveCard(list[1]);
            PlayerOne.GiveCard(list[2]);
            PlayerTwo.GiveCard(list[3]);
        }

        public override void TakeCard()
        {
            RacingCardsPlayerOne.Add(RacingCardManager.TakeCard());
            RacingCardsPlayerTwo.Add(RacingCardManager.TakeCard());
        }

    }
}