using System;
using System.Collections.Generic;
using System.Linq;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public class TwoPlayersQuantityType : PlayersQuantityTypeBase
    {
        public override int NumberOfPlayers => 2;
        public sealed override IPlayer PlayerOne { get; }
        public sealed override IPlayer PlayerTwo { get; }

        public TwoPlayersQuantityType(IPlayer playerOne, IPlayer playerTwo)
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
            PlayerOne.TakeRacingCard();
            PlayerTwo.TakeRacingCard();
        }
        public override void ChooseSecondBet()
        {
            PlayerOne.ChooseSecondBet();
            PlayerTwo.ChooseSecondBet();
        }
        public override bool CardsTurn(Func<IReadOnlyCollection<IRacingCard>, bool> cardsTurnCallback)
        {
            return PlayerOne.CardsTurn(cardsTurnCallback);
        }
    }
}