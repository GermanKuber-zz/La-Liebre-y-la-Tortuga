using System.Collections.Generic;
using TurtleGame.Domain.BetCards;
using TurtleGame.Domain.Player.Interfaces;

namespace TurtleGame.Domain.Player.PlayersQuantityType.Interfaces
{
    public interface IPlayersQuantityType
    {
        void GiveCards(IReadOnlyCollection<IBetCard> betsCards);
        /// <summary>
        /// Deal one raicing card to each player
        /// </summary>
        void TakeCard();
        int NumberOfPlayers { get; }
        IPlayer PlayerFive { get; }
        IPlayer PlayerFour { get; }
        IPlayer PlayerOne { get; }
        IPlayer PlayerThree { get; }
        IPlayer PlayerTwo { get; }
        void ChooseSecondBet();
        bool CardsTurn(SelectedCardsConfirmationDelegate cardsTurnCallback);
    }
}