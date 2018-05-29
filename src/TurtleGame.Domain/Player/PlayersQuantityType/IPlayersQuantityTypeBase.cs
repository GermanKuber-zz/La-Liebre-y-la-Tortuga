using System;
using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;
using TurtleGame.Domain.Player.PlayersQuantityType.Interfaces;
using TurtleGame.Domain.Player.Types;
using TurtleGame.Domain.RacingCards.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType
{
    public abstract class PlayersQuantityTypeBase : IPlayersQuantityType
    {
      
        public abstract void GiveCards(IReadOnlyCollection<IBetCard> betsCards);
        public abstract void TakeCard();

        public abstract void ChooseSecondBet();
        public abstract bool CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback);

        public abstract int NumberOfPlayers { get; }
        public virtual IPlayer PlayerOne => NonePlayer.Create;
        public virtual IPlayer PlayerTwo => NonePlayer.Create;
        public virtual IPlayer PlayerThree => NonePlayer.Create;
        public virtual IPlayer PlayerFour => NonePlayer.Create;
        public virtual IPlayer PlayerFive => NonePlayer.Create;


    }
}